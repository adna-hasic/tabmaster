import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormGroup } from '@angular/forms';
import { TablesApiService } from '../../../../api-services/tables/tables-api.service';
import { ToasterService } from '../../../../core/services/toaster.service';
import { applyServerErrors } from '../../../../core/forms/server-errors';
import { TableForm, TableFormService } from '../services/table-form.service';
import { TranslateService } from '@ngx-translate/core';

export interface TableDialogData {
  mode: 'create' | 'edit';
  tableId?: number;
}

@Component({
  selector: 'app-table-upsert',
  standalone: false,
  templateUrl: './table-upsert.component.html',
  styleUrl: './table-upsert.component.scss',
  providers: [TableFormService],
})
export class TableUpsertComponent implements OnInit {
  private dialogRef = inject(MatDialogRef<TableUpsertComponent>);
  private data = inject<TableDialogData>(MAT_DIALOG_DATA);
  private api = inject(TablesApiService);
  private formService = inject(TableFormService);
  private toaster = inject(ToasterService);
  private destroyRef = inject(DestroyRef);
  private translate = inject(TranslateService);

  form?: FormGroup<TableForm>;
  isLoading = false;
  isEditMode = false;
  errorMessage: string | null = null;

  ngOnInit(): void {
    this.isEditMode = this.data.mode === 'edit';

    if (this.isEditMode) {
      if (!this.data.tableId) {
        this.dialogRef.close(false);
        return;
      }

      this.loadTable(this.data.tableId);
    } else {
      this.form = this.formService.createTableForm();
    }
  }

  private loadTable(id: number): void {
    this.isLoading = true;

    this.api.getById(id)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: (table) => {
          this.form = this.formService.createTableForm(table);
          this.isLoading = false;
        },
        error: (err) => {
          this.toaster.error(
            this.translate.instant('TABLES.LOAD_ERROR')
          );
        },
      });
  }

  onSubmit(): void {
    const form = this.form;

    if (!form || this.isLoading) {
      return;
    }

    if (form.invalid) {
      form.markAllAsTouched();
      return;
    }

    const tableNumber = form.controls.tableNumber.value;

    if (tableNumber === null) {
      return;
    }

    const command = {
      tableNumber,
      isEnabled: form.controls.isEnabled.value,
    };

    this.isLoading = true;
    this.errorMessage = null;

    if (this.isEditMode && this.data.tableId) {
      this.api.update(this.data.tableId, command)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe({
          next: () => this.dialogRef.close(true),
          error: (err) => {
            this.isLoading = false;
            this.errorMessage = applyServerErrors(form, err);
          },
        });
    } else {
      this.api.create(command)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe({
          next: () => this.dialogRef.close(true),
          error: (err) => {
            this.isLoading = false;
            this.errorMessage = applyServerErrors(form, err);
          },
        });
    }
  }

  onCancel(): void {
    if (!this.isLoading) {
      this.dialogRef.close(false);
    }
  }
}