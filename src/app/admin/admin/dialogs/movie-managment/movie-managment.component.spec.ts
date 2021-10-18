import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieManagmentComponent } from './movie-managment.component';

describe('MovieManagmentComponent', () => {
  let component: MovieManagmentComponent;
  let fixture: ComponentFixture<MovieManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
