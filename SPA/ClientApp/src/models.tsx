export interface BuyerInfo {
    id: string | null | undefined;
    personId: string | null | undefined;
    name: string;
    address: string;
    unitId: string | null | undefined;
    projectName: string;
    condoUnit: string;
    loanAmount: number;
    term: number;
    startOfPayment: Date;
    interestRate: number;
};

export interface AmortizationSchedule {
    id: string | null | undefined;
    personUnitId: string | null | undefined;
    date: Date;
    principal: number;
    interest: number;
    loanAmount: number;
    noOfDays: number;
    total: number;
    balance: number;
};

export const BuyerInfoDefaultValues: BuyerInfo = {
    id: undefined,
    personId: undefined,
    name: '',
    address: '',
    unitId: undefined,
    projectName: '',
    condoUnit: '',
    loanAmount: 0,
    term: 0,
    startOfPayment: new Date(),
    interestRate: 0
};