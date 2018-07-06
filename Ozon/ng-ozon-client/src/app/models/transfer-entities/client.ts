import { IEntity } from '../Interfaces/entity.interface';

export class Client implements IEntity {

    constructor(
        public readonly id: number,
        public name: string,
        public phone: string,
        public email: string
    ) {}

}
