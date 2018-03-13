import { VexflowComponent } from './vexflow-component/vexflow-component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent, VexflowComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent],
  exports: [VexflowComponent]
})
export class AppModule {}
