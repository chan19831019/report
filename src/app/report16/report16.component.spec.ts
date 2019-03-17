import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Report16Component } from './report16.component';

describe('Report16Component', () => {
  let component: Report16Component;
  let fixture: ComponentFixture<Report16Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Report16Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Report16Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
