import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Report14Component } from './report14.component';

describe('Report14Component', () => {
  let component: Report14Component;
  let fixture: ComponentFixture<Report14Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Report14Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Report14Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
