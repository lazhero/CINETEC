import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-movie-menu',
  templateUrl: './movie-menu.component.html',
  styleUrls: ['./movie-menu.component.css'],
})
export class MovieMenuComponent implements OnInit {
  constructor(public snackmat: MatSnackBar, private swal: SwalService) {}
  chairs: any[] = [];
  projections: any[] = [];
  scrollableItemSize = 100;

  currentProjection: any;
  currentChair: any;

  @ViewChild('panel', { read: ElementRef }) public panel: any;
  randomIntFromInterval(min: number, max: number) {
    // min and max included
    return Math.floor(Math.random() * (max - min + 1) + min);
  }
  getRandomBool() {
    var numb = this.randomIntFromInterval(0, 100);

    return numb % 2 === 0;
  }

  ngOnInit(): void {
    for (let i = 0; i < 50; i++) {
      const newChair = {
        state: this.getRandomBool(),
        number: 'A' + i,
        selected: false,
      };

      this.chairs.push(newChair);
    }

    for (let i = 0; i < 20; i++) {
      const newProjection = {
        room: 'S' + i,
        hour: i + ':00',
        selected: false,
      };
      this.projections.push(newProjection);
    }
  }

  /**
   * It verifies the process of buying tickets and do the buy
   * @returns
   */
  buyTicket(): void {
    if (!this.currentProjection || !this.currentChair) {
      this.swal.showError(
        'Error',
        'Por favor seleccione una sala y un asiento válido'
      );
      return;
    }

    this.swal
      .htmloptionSwal(
        'Compra de tiquete',
        'A continuación se procederá a realizar la compra del tiquete <br><br> Sala:' +
          this.currentProjection.room +
          '<br>Asiento:' +
          this.currentChair.number +
          '<br><br> Por favor inserte su targeta de crédito para realizar la compra',
        'Cancelar',
        'Comprar',
        '',
        'text'
      )
      ?.then((result) => {
        if (String(result.value).length < 1) {
          this.swal.showError('Error', 'inserte una targeta de crédito válida');
          return;
        }

        if (result.isConfirmed) {
          this.swal.showSuccess(
            'Tiquete comprado',
            'Descargando tu tiquete y tu factura,  ¡Nos vemos!'
          );
        }
      });
  }
  /**
   * Unselect all chairs
   */
  unselectAllChairs() {
    this.chairs.forEach((chair) => {
      chair.selected = false;
    });
    this.currentChair = null;
  }
  /**
   * Projections
   */
  unselectAllProjections() {
    this.projections.forEach((projection) => {
      projection.selected = false;
    });
    this.currentProjection = null;
  }
  selectProjection(projection: any) {
    this.unselectAllProjections();
    projection.selected = true;
    this.currentProjection = projection;
  }

  selectChair(chair: any) {
    this.unselectAllChairs();
    chair.selected = true;
    this.currentChair = chair;
  }
  /**
   * moves the (itemScroll) projectionsScroll to the left
   */
  moveLeft(): void {
    this.panel.nativeElement.scrollTo({
      left: this.panel.nativeElement.scrollLeft - this.scrollableItemSize,
      behavior: 'smooth',
    });
  }

  /**
   * moves the (itemScroll) projectionsScroll to the Right
   */
  moveRight(): void {
    this.panel.nativeElement.scrollTo({
      left: this.panel.nativeElement.scrollLeft + this.scrollableItemSize,
      behavior: 'smooth',
    });
  }
}
