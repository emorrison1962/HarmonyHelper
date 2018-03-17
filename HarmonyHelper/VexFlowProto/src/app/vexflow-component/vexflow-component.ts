import { Component, OnInit } from '@angular/core';
import * as Vex from 'vexflow';
import { HarmonyServiceService } from '../harmony-service/harmony-service.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-vexflow-component',
  templateUrl: './vexflow-component.html',
  styleUrls: ['./vexflow-component.css']
})
export class VexflowComponent implements OnInit {
  renderer: Vex.Flow.Renderer;
  context: Vex.IRenderContext;
  stave: Vex.Flow.Stave;
  div: HTMLElement;
  flow: Object;

  _staveNotes :Vex.Flow.StaveNote[];

  get staveNotes() :Vex.Flow.StaveNote[]{ return this._staveNotes;}
  set staveNotes(input: Vex.Flow.StaveNote[]) { 
    this._staveNotes = input;
    this.setNotes();
  }

  constructor(private svc: HarmonyServiceService) {}

  ngOnInit() {

    this.getData();
    const VF = Vex.Flow;
    this.flow = Vex.Flow;
    // Create an SVG renderer and attach it to the DIV element named "vexflow".
    this.div = document.getElementById('vexflow');
    this.renderer = new VF.Renderer(this.div, VF.Renderer.Backends.SVG);
    // Configure the rendering context.
    this.renderer.resize(500, 500);
    this.context = this.renderer.getContext();
    // context.setFont('Arial', 10, '').setBackgroundFillStyle('#eed');
    // Create a stave of width 400 at position 10, 40 on the canvas.
    this.stave = new VF.Stave(10, 40, 400);
    // Add a clef and time signature.
    this.stave.addClef('treble'); // .addTimeSignature('4/4');
    // Connect it to the rendering context and draw!
    this.stave.setContext(this.context).draw();

    this.getNotes();
  }

getData(){
  const promise = this.svc.getData().toPromise();
  promise.then((notes: Array<IStaveNote>) => {

    const staveNotes = new Array<Vex.Flow.StaveNote> ();
    
    notes.forEach((note: IStaveNote)=>{
      let staveNote = new Vex.Flow.StaveNote({
        clef: note.clef,
        keys: note.keys,
        duration: note.duration,
        auto_stem: note.auto_stem
      });
      staveNotes.push(staveNote);
    });

        this.staveNotes = staveNotes;
      })
    .catch((error:  HttpErrorResponse) => {
      console.error(error.statusText);
    });
}

setNotes() {
  const VF = Vex.Flow;


  // Create a voice in 4/4 and add above notes
  const voice = new VF.Voice({ num_beats: 4, beat_value: 4 });
  voice.setStrict(false);
  voice.addTickables(this.staveNotes);

  // Format and justify the notes to 400 pixels.
  const formatter = new VF.Formatter()
    .joinVoices([voice])
    .format([voice], 400);

  // Render voice
  voice.draw(this.context, this.stave);

}


  getNotes() {
    const VF = Vex.Flow;

    const notes = [
      // A quarter-note C.
      new VF.StaveNote({
        clef: 'treble',
        keys: ['c/4'],
        duration: 'q',
        auto_stem: true
      }), // A quarter-note D.
      new VF.StaveNote({
        clef: 'treble',
        keys: ['d/4'],
        duration: 'q'
      }), // A quarter-note rest. Note that the key (b/4) specifies the vertical
      // position of the rest.
      new VF.StaveNote({
        clef: 'treble',
        keys: ['b/4'],
        duration: 'qr'
      }), // A C-Major chord.
      new VF.StaveNote({
        clef: 'treble',
        keys: ['c/4', 'e/4', 'g/4'],
        duration: 'q'
      })
    ];

    // Create a voice in 4/4 and add above notes
    const voice = new VF.Voice({ num_beats: 4, beat_value: 4 });
    voice.setStrict(false);
    voice.addTickables(notes);

    // Format and justify the notes to 400 pixels.
    const formatter = new VF.Formatter()
      .joinVoices([voice])
      .format([voice], 400);

    // Render voice
    voice.draw(this.context, this.stave);
  }
}

export interface IStaveNote {
  clef: string; //'treble',
  keys: string[]; //['c/4'],
  duration: string;// 'q',
  auto_stem: boolean
}
