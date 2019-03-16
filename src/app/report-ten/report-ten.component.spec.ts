import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportTenComponent } from './report-ten.component';

describe('ReportTenComponent', () => {
  let component: ReportTenComponent;
  let fixture: ComponentFixture<ReportTenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportTenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportTenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
