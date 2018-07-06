import { IEntity } from '../Interfaces/entity.interface';

export class Good implements IEntity {

    constructor(
        public readonly id: number,
        public name: string,
        public price: number
    ) { }

}
