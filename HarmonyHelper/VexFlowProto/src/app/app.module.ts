import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { VexflowComponent } from './vexflow-component/vexflow-component';

import { AppComponent } from './app.component';
import { HarmonyServiceService } from './harmony-service/harmony-service.service';

@NgModule({
  declarations: [AppComponent, VexflowComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [HarmonyServiceService],
  bootstrap: [AppComponent],
  exports: [VexflowComponent]
})
export class AppModule {}
