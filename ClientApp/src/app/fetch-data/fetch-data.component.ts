import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public cityVisits: CityVisits[] = [];
  city: any

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CityVisits[]>(baseUrl + 'CityVisits').subscribe(result => {
      this.cityVisits = result;
    }, error => console.error(error));
  }

  Search() {

  }
}

interface CityVisits {
  city: string;
  startDate: number;
  endDate: number;
  price: number;
  status: string;
  color: string
}
