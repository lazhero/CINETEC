import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Covid19ManagmentComponent } from './covid19-managment.component';

describe('Covid19ManagmentComponent', () => {
  let component: Covid19ManagmentComponent;
  let fixture: ComponentFixture<Covid19ManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Covid19ManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Covid19ManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
