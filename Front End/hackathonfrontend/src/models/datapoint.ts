import {latlong} from './latlong';

// tslint:disable-next-line:class-name
export class datapoint {
    carId: number;
    dateTimeStamp: string;
    emissionType: string;
    laneMaxSpeedMs: number;
    lat_long: latlong;
    routeId: number;
    vehicleTypeName: string;
}
