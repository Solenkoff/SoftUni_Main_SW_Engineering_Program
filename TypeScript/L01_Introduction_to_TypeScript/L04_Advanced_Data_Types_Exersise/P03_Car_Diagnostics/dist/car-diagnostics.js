"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function carDiagnostics(carBody, tires, engine) {
    console.log(carBody.runDiagnostics());
    console.log(tires);
    console.log(engine);
}
carDiagnostics({ material: 'aluminum', state: 'scratched', partName: 'Car Body', runDiagnostics() { return this.partName; } }, { airPressure: 30, condition: 'needs change', partName: 'Tires', runDiagnostics() { return this.partName; } }, { horsepower: 300, oilDensity: 780, partName: 'Engine', runDiagnostics() { return this.partName; } });
//# sourceMappingURL=car-diagnostics.js.map