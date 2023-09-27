export interface IInvoiceDetails {
    id: number,
    amount: number,
    description: string,
    customerName: string,
    billingPeriod: string,
    billingStatusId: number,
    createDate: Date
}
