// E01 — envoltorio mínimo del puente JS <-> C# (lado contenido).
// Usa window.HybridWebView.InvokeDotNet, que inyecta el cascarón en _framework/hybridwebview.js.
window.e01 = {
    marca: function (nombre) {
        const t = Math.round(performance.now());
        console.log('E01-MARCA ' + nombre + ' perf.now=' + t + 'ms');
        if (window.HybridWebView && window.HybridWebView.InvokeDotNet) {
            window.HybridWebView.InvokeDotNet('Marca', [nombre, t]).catch(function (e) { console.log('E01-MARCA error ' + e); });
        }
    },
    primerRender: function (version) { window.e01.marca('primer-render ' + version); },
    deviceInfo: async function () {
        if (!(window.HybridWebView && window.HybridWebView.InvokeDotNet)) {
            return 'SIN PUENTE: window.HybridWebView no existe';
        }
        const r = await window.HybridWebView.InvokeDotNet('DeviceInfo');
        console.log('E01-PUENTE device.info=' + r);
        return r;
    }
};
window.e01.marca('index-html-cargado');
