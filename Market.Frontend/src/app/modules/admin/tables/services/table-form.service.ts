import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GetTableByIdQueryDto } from '../../../../api-services/tables/tables-api.model';

export interface TableForm {
  tableNumber: FormControl<number | null>;
  isEnabled: FormControl<boolean>;
}

@Injectable()
export class TableFormService {
  createTableForm(table?: GetTableByIdQueryDto): FormGroup<TableForm> {
    return new FormGroup<TableForm>({
      tableNumber: new FormControl<number | null>(
        table?.tableNumber ?? null,
        {
          validators: [
            Validators.required,
            Validators.min(1),
            Validators.max(2147483647),
            Validators.pattern(/^\d+$/),
          ],
        }
      ),
      isEnabled: new FormControl(table?.isEnabled ?? true, {
        nonNullable: true,
      }),
    });
  }
}