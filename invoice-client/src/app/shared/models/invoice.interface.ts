export interface IInvoice {
    id: number,
    amount: number,
    billingStatus: string,
    createDate: Date
}

export interface IInvoiceList {
    invoiceList: Array<IInvoice>
}
