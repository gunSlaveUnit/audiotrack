export interface IRepository<T> {
    GetAsync(): Promise<T[]>;
}