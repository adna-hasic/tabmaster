import { Component, inject, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import { TablesApiService } from '../../../api-services/tables/tables-api.service';
import {
  ListTablesRequest,
  ListTablesQueryDto,
} from '../../../api-services/tables/tables-api.model';
import { ToasterService } from '../../../core/services/toaster.service';
import {
  DialogButton,
  DialogType,
} from '../../shared/models/dialog-config.model';
import { FitConfirmDialogComponent } from '../../shared/components/fit-confirm-dialog/fit-confirm-dialog.component';
import { TableUpsertComponent } from './table-upsert/table-upsert.component';

@Component({
  selector: 'app-tables',
  standalone: false,
  templateUrl: './tables.component.html',
  styleUrl: './tables.component.scss',
})
export class TablesComponent
  extends BaseListPagedComponent<ListTablesQueryDto, ListTablesRequest>
  implements OnInit {
  private api = inject(TablesApiService);
  private dialog = inject(MatDialog);
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);

  displayedColumns: string[] = ['tableNumber', 'isEnabled', 'actions'];

  constructor() {
    super();
    this.request = new ListTablesRequest();
  }

  ngOnInit(): void {
    this.initList();
  }

  protected loadPagedData(): void {
    this.startLoading();

    this.api.list(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading(
          this.translate.instant('TABLES.LOAD_LIST_ERROR')
        );
        console.error('Load tables error:', err);
      },
    });
  }

  onTableNumberChange(tableNumber: number | null): void {
    this.request.tableNumber = tableNumber;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  onStatusChange(onlyEnabled: boolean | null): void {
    this.request.onlyEnabled = onlyEnabled;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  onCreate(): void {
    const dialogRef = this.dialog.open(TableUpsertComponent, {
      width: '500px',
      maxWidth: '90vw',
      disableClose: true,
      data: {
        mode: 'create',
      },
    });

    dialogRef.afterClosed().subscribe((success: boolean) => {
      if (success) {
        this.toaster.success(
          this.translate.instant('TABLES.CREATE_SUCCESS')
        );
        this.loadPagedData();
      }
    });
  }

  onEdit(table: ListTablesQueryDto): void {
    const dialogRef = this.dialog.open(TableUpsertComponent, {
      width: '500px',
      maxWidth: '90vw',
      disableClose: true,
      data: {
        mode: 'edit',
        tableId: table.id,
      },
    });

    dialogRef.afterClosed().subscribe((success: boolean) => {
      if (success) {
        this.toaster.success(
          this.translate.instant('TABLES.UPDATE_SUCCESS')
        );
        this.loadPagedData();
      }
    });
  }

  onDelete(table: ListTablesQueryDto): void {
    if (this.isLoading) {
      return;
    }

    const dialogRef = this.dialog.open(FitConfirmDialogComponent, {
      width: '420px',
      maxWidth: '90vw',
      panelClass: 'table-delete-dialog',
      data: {
        type: DialogType.WARNING,
        titleKey: 'TABLES.DELETE_TITLE',
        titleParams: { number: table.tableNumber },
        messageKey: 'TABLES.DELETE_MESSAGE',
        icon: 'delete_outline',
        buttons: [
          {
            type: DialogButton.CANCEL,
            translationKey: 'TABLES.CANCEL',
          },
          {
            type: DialogButton.DELETE,
            translationKey: 'TABLES.CONFIRM_DELETE',
            color: 'warn',
          },
        ],
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result?.button === DialogButton.DELETE) {
        this.performDelete(table);
      }
    });
  }

  private performDelete(table: ListTablesQueryDto): void {
    this.startLoading();

    this.api.delete(table.id).subscribe({
      next: () => {
        this.toaster.success(
          this.translate.instant('TABLES.DELETE_SUCCESS')
        );
        this.loadPagedData();
      },
      error: (err) => {
        this.stopLoading();
        this.toaster.error(
          err?.error?.message ||
          this.translate.instant('TABLES.DELETE_ERROR')
        );
      },
    });
  }
}