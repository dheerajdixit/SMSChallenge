import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public cityVisits: CityVisits[] = [];
  public tempCityVisits: CityVisits[] = [];
  city: string
  http: HttpClient
  baseUrl: string
  p: number = 1
  selected: any
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

  change(k: any) {

    this.http.get<CityVisits[]>(this.baseUrl + 'CityVisits').subscribe(result => {
      this.tempCityVisits = result;
    }, error => console.error(error));

    let startDate = new Date(k.startDate.$d);

    let endDate = new Date(k.endDate.$d);
    console.log(startDate)
    console.log(endDate)

    this.cityVisits = this.tempCityVisits.filter(res => {
      return new Date(res.startDate) >= startDate && new Date( res.endDate)<= endDate

    })


  }
  //change(k: any) {

  //  console.log(k)
  //  this.cityVisits = this.cityVisits.filter(res => {
  //    return res.startDate.getTime() >= k.startDate.$d && res.startDate.getTime() <= k.endDate.$d

  //    })


  //}
  Search() {
    if (this.city == '') {
      this.ngOnInit();
    }
    else {
      this.cityVisits = this.cityVisits.filter(res => {
        return res.city.toLocaleLowerCase().match(this.city.toLocaleLowerCase())

      })
    }
  }

  key: string = "id"
  reverse: boolean = false
  Sort(key: any) {
    this.key = key
    this.reverse = !this.reverse
  }

}

interface CityVisits {
  city: string;
  startDate: Date;
  endDate: Date;
  price: number;
  status: string;
  color: string
}
