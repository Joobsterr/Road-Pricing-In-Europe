import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {UserDTO} from '../models/UserDTO';
import {Router} from '@angular/router';
import {RegisterDTO} from '../models/RegisterDTO';
import {LicenseDTO} from '../models/LicenseDTO';
@Injectable({
  providedIn: 'root'
})
export class AppService {

   rootUrl = '/api';


  constructor(
      private http: HttpClient,
      public router: Router
  ) { }
  getUsersByID(id: string) {
    return this.http.get( this.rootUrl + '/User/getUsersByID/' + id);
  }
  login(nUser: UserDTO) {
    return this.http.post(this.rootUrl + '/User/login', nUser)
  }
  register(nRegister: RegisterDTO) {
    return this.http.post(this.rootUrl + '/User/register', nRegister)
  }
  addNewCar(Licenseplate: string, id: number) {
    const licenseDTO = new LicenseDTO();
    licenseDTO.userID = id;
    licenseDTO.Licenseplate = Licenseplate;
    return this.http.post(this.rootUrl + '/Car/addNewCar', licenseDTO)
  }
  getCarsByUser(userID: string) {
    return this.http.get(this.rootUrl + '/Car/getCarsByUser/' + userID)
  }
}
