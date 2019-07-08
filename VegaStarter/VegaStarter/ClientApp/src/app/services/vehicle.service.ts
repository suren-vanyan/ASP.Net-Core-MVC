import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from } from 'rxjs';



// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class VehicleService {

  makesUrl = 'api/makes/all-makes';
  constructor(private httpClient: HttpClient) { }

  getMakes() {
    return this.httpClient.get(this.makesUrl) ;
  }

  getFeatures() {
    return this.httpClient.get('api/features/all-features');
   }


}
