import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { RoomManagmentComponent } from '../room-managment/room-managment.component';

@Component({
  selector: 'app-covid19-managment',
  templateUrl: './covid19-managment.component.html',
  styleUrls: ['./covid19-managment.component.css'],
})
export class Covid19ManagmentComponent implements OnInit {
  max_seats: string = '';
  constructor(public dialogRef: MatDialogRef<RoomManagmentComponent>) {}

  ngOnInit(): void {}
  create() {}
  close(): void {
    this.dialogRef.close();
  }
}
