import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieTheatersBoardsComponent } from './movie-theaters-boards.component';

describe('MovieTheatersBoardsComponent', () => {
  let component: MovieTheatersBoardsComponent;
  let fixture: ComponentFixture<MovieTheatersBoardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieTheatersBoardsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieTheatersBoardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
