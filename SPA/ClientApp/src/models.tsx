export interface BuyerInfo {
    id: string;
    personId: string;
    name: string;
    address: string;
    unitId: string;
    projectName: string;
    condoUnit: string;
    loanAmount: number;
    term: number;
    startOfPayment: Date;
    interestRate: number;
};

export interface AmortizationSchedule {
    personUnitId: string;
    date: Date;
    principal: number;
    interest: number;
    loanAmount: number;
    noOfDays: number;
    total: number;
    balance: number;
};

export const BuyerInfoDefaultValues: BuyerInfo = {
    id: '',
    personId: '',
    name: '',
    address: '',
    unitId: '',
    projectName: '',
    condoUnit: '',
    loanAmount: 0,
    term: 0,
    startOfPayment: new Date(),
    interestRate: 0
};