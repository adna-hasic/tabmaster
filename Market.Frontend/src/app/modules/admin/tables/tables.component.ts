import { Component, inject, OnInit } from '@angular/core';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import { TablesApiService } from '../../../api-services/tables/tables-api.service';
import {
  ListTablesRequest,
  ListTablesQueryDto,
} from '../../../api-services/tables/tables-api.model';

@Component({
  selector: 'app-tables',
  standalone: false,
  templateUrl: './tables.component.html',
  styleUrl: './tables.component.scss',
})

export class TablesComponent
  extends BaseListPagedComponent<ListTablesQueryDto, ListTablesRequest>
  implements OnInit
{
  private api = inject(TablesApiService);

  displayedColumns: string[] = ['tableNumber', 'isEnabled'];

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
          'Učitavanje stolova nije uspjelo. Pokušajte ponovo.'
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
}