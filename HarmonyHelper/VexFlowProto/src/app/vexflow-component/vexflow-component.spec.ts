/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { VexflowComponent } from './vexflow-component';

describe('VexflowComponent', () => {
  let component: VexflowComponent;
  let fixture: ComponentFixture<VexflowComponent>;

  beforeEach(
    async(() => {
      TestBed.configureTestingModule({
        declarations: [VexflowComponent]
      }).compileComponents();
    })
  );

  beforeEach(() => {
    fixture = TestBed.createComponent(VexflowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
