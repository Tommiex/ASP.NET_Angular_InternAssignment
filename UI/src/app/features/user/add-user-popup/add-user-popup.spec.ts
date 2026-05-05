import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUserPopup } from './add-user-popup';

describe('AddUserPopup', () => {
  let component: AddUserPopup;
  let fixture: ComponentFixture<AddUserPopup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddUserPopup],
    }).compileComponents();

    fixture = TestBed.createComponent(AddUserPopup);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
