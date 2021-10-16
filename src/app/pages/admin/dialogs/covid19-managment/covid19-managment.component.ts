import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { RoomManagmentComponent } from '../room-managment/room-managment.component';

@Component({
  selector: 'app-covid19-managment',
  templateUrl: './covid19-managment.component.html',
  styleUrls: ['./covid19-managment.component.css'],
})
export class Covid19ManagmentComponent implements OnInit {
  max_seats: number = 0;
  constructor(
    public dialogRef: MatDialogRef<RoomManagmentComponent>,
    public swal: SwalService,
    public backend: BackendService
  ) {}

  ngOnInit(): void {}
  submitModify() {
    if (this.max_seats < 0 || this.max_seats > 100) {
      this.swal.showError('Error', 'Ingrese un porcentaje entre 0 y 100');
      return;
    }

    this.backend.get_request('Admin/Sucursales', null).subscribe((cinemas) => {
      cinemas.forEach((cinema: { name: string }) => {
        this.backend
          .get_request('Admin/Sucursales/Room', { cinema_name: cinema.name })
          .subscribe((rooms) => {
            rooms.forEach((room: any) => {
              room.restrictionPercent = this.max_seats;
              console.log(room);

              this.backend
                .put_request('Admin/Sucursales/Room', room)
                .subscribe((value) => {
                  this.swal.showSuccess('Éxito', 'Aforo cambiado con éxito');
                });
            });
          });
      });
    });
  }
  close(): void {
    this.dialogRef.close();
  }
}
