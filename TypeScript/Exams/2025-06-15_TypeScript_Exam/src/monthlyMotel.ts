import { PartialMonthlyMotel } from "./contracts/partialMonthlyMotel"
import { Room } from "./contracts/room";
import { RoomNumber, SeasonalMonth } from "./types";

export class MonthlyMotel<T extends SeasonalMonth> extends PartialMonthlyMotel {

    private totalBudget: number = 0;
    private rooms: Map<RoomNumber, Room>;
    private bookings: Map<RoomNumber, Set<T>>;

    constructor() {
        super();
        this.rooms = new Map<RoomNumber, Room>();
        this.bookings = new Map<RoomNumber, Set<T>>();
    }


   

}

