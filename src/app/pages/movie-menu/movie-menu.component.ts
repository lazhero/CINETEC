import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-movie-menu',
  templateUrl: './movie-menu.component.html',
  styleUrls: ['./movie-menu.component.css'],
})
export class MovieMenuComponent implements OnInit {
  constructor() {}

  scrollableItemSize = 100;

  @ViewChild('panel', { read: ElementRef }) public panel: any;
  ngOnInit(): void {}

  moveLeft(): void {
    this.panel.nativeElement.scrollTo({
      left: this.panel.nativeElement.scrollLeft - this.scrollableItemSize,
      behavior: 'smooth',
    });
  }
  moveRight(): void {
    this.panel.nativeElement.scrollTo({
      left: this.panel.nativeElement.scrollLeft + this.scrollableItemSize,
      behavior: 'smooth',
    });
  }
}
