import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionRegistryViewToggleComponent } from './reception-registry-view-toggle.component';

describe('ReceptionRegistryViewToggleComponent', () => {
  let component: ReceptionRegistryViewToggleComponent;
  let fixture: ComponentFixture<ReceptionRegistryViewToggleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReceptionRegistryViewToggleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionRegistryViewToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
