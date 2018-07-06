import { Order } from './order';

export class OrdersDiff {

    constructor(
        public deletedOrdersIds: number[],
        public addedOrders: Order[],
        public updatedOrders: Order[]
    ) { }

}
