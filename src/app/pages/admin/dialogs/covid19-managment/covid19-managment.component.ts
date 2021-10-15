import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-covid19-managment',
  templateUrl: './covid19-managment.component.html',
  styleUrls: ['./covid19-managment.component.css']
})
export class Covid19ManagmentComponent implements OnInit {


  max_seats: string = '';
  constructor() { }

  ngOnInit(): void {
  }

}
