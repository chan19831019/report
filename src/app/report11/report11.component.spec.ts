import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Report11Component } from './report11.component';

describe('Report11Component', () => {
  let component: Report11Component;
  let fixture: ComponentFixture<Report11Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Report11Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Report11Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
