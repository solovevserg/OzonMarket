import { Client } from './client';
import { OrderStates } from '../enums/order-states.enum';
import { Good } from './good';
import { IEntity } from '../Interfaces/entity.interface';

export class Order implements IEntity {

    constructor(
        public readonly id: number,
        public client: Client,
        public time: Date,
        public state: OrderStates,
        public goods: Good[]
    ) { }

}
