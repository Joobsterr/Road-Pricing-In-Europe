import { Trip } from "./Trip";

export class Bill {
    id: number;
    userId: number;
    trips: Array<Trip>;
    month: string;
    year: number;
    totalPrice: number;
}
