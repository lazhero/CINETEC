import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientManagmentComponent } from './client-managment.component';

describe('ClientManagmentComponent', () => {
  let component: ClientManagmentComponent;
  let fixture: ComponentFixture<ClientManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
