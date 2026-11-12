import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { PageResult } from '../../core/models/paging/page-result';

export class ListTablesRequest extends BasePagedQuery {
    tableNumber?: number | null;
    onlyEnabled?: boolean | null;
}

export interface ListTablesQueryDto {
    id: number;
    tableNumber: number;
    isEnabled: boolean;
}

export interface GetTableByIdQueryDto {
    id: number;
    tableNumber: number;
    isEnabled: boolean;
}

export interface CreateTableCommand {
    tableNumber: number;
    isEnabled: boolean;
}

export interface UpdateTableCommand {
    tableNumber: number;
    isEnabled: boolean;
}

export type ListTablesResponse = PageResult<ListTablesQueryDto>;