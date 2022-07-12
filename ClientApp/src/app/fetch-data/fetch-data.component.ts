import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public cityVisits: CityVisits[] = [];
  city: string
  http: HttpClient
  baseUrl: string
  p: number = 1
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.city = ''
    this.http = http
    this.baseUrl = baseUrl


  }
    ngOnInit(): void {
      this.http.get<CityVisits[]>(this.baseUrl + 'CityVisits').subscribe(result => {
        this.cityVisits = result;
      }, error => console.error(error));
    }


  Search() {
    if (this.city == '') {
      this.ngOnInit();
    }
    else {
      this.cityVisits=  this.cityVisits.filter(res => {
      return res.city.toLocaleLowerCase().match(this.city.toLocaleLowerCase())
   
      })
    }
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
