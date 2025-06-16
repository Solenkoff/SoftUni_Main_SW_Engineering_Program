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


    getTotalBudget() {
        const hotelNameString = super.getTotalBudget();
        return `${hotelNameString}\nTotal budget: $${this.totalBudget.toFixed(2)}`;
    }

    addRoom(room: unknown): string {
        if (!this.isRoom(room)) {
            return `Value was not a Room.`;
        }

        return "";
    }


    private isRoom(possibleRoom: unknown): possibleRoom is Room {
        return possibleRoom !== null && typeof possibleRoom === 'object' &&
            'roomNumber' in possibleRoom && typeof possibleRoom.roomNumber === 'string' &&
            ['A01', 'A02', 'A03', 'B01', 'B02', 'B03'].includes(possibleRoom.roomNumber) &&
            'totalPrice' in possibleRoom && typeof possibleRoom.totalPrice === 'number' &&
            'cancellationPrice' in possibleRoom && typeof possibleRoom.cancellationPrice === 'number';
    }
}

