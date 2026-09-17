<!DOCTYPE html>
<html lang="es">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Credenciales de proveedor — maqueta</title>
<style>
:root{
  --ink:#0d2622; --ink-soft:#3b524e; --muted:#71857f;
  --line:#e3eae7; --bg:#eef3f1; --surface:#ffffff;
  --primario:#236c9c; --primario-deep:#17537a; --primario-tint:#e1f1ee; --primario-tint-2:#f1f8f6;
  --secundario:#4f46e5; --secundario-tint:#e0e7ff;
  --terciario:#7c3aed; --terciario-tint:#ede9fe;
  --danger:#d63a4a; --danger-tint:#fcebed;
  --success:#16a34a; --success-tint:#dcfce7;
  --warning:#e08a16; --warning-tint:#fbf1dd;
  --radius:20px; --radius-sm:13px;
  --shadow-sm:0 1px 2px rgba(13,38,34,.05);
  --shadow:0 2px 10px rgba(13,38,34,.07);
  --shadow-hover:0 6px 22px rgba(13,38,34,.10);
  --ease:cubic-bezier(.22,.61,.36,1);
}
html[data-theme="dark"]{
  --ink:#e7f0ed; --ink-soft:#b6c8c3; --muted:#8b9d98;
  --line:#1e3a35; --bg:#0d1c1a; --surface:#132a26;
  --primario-tint:#173f3a; --primario-tint-2:#14332f;
  --secundario-tint:#241f52; --terciario-tint:#2b1f4a;
  --danger-tint:#3d1c22; --success-tint:#123521; --warning-tint:#3a2c10;
  --shadow-sm:0 1px 2px rgba(0,0,0,.4);
  --shadow:0 2px 10px rgba(0,0,0,.45);
  --shadow-hover:0 6px 22px rgba(0,0,0,.5);
}
*{box-sizing:border-box}
body{margin:0;background:var(--bg);color:var(--ink);
  font-family:'Inter',system-ui,-apple-system,'Segoe UI',sans-serif;font-size:15px;line-height:1.55;
  -webkit-font-smoothing:antialiased}
a{color:var(--primario);text-decoration:none}
.visually-hidden{position:absolute!important;width:1px;height:1px;padding:0;margin:-1px;overflow:hidden;clip:rect(0,0,0,0);white-space:nowrap;border:0}
:focus-visible{outline:2px solid var(--primario);outline-offset:2px;border-radius:4px}

/* ---------- controles de la maqueta (no son del sistema) ---------- */
.demo{background:var(--ink);color:#fff;font-size:12.5px;padding:8px 24px;display:flex;gap:10px;align-items:center;flex-wrap:wrap}
.demo span{opacity:.6;margin-right:4px}
.demo button{font:inherit;background:transparent;color:#fff;border:1px solid rgba(255,255,255,.35);
  border-radius:999px;padding:3px 12px;cursor:pointer}
.demo button[aria-pressed="true"]{background:#fff;color:var(--ink);border-color:#fff}

/* ---------- topbar ---------- */
.topbar{position:sticky;top:0;z-index:50;background:var(--surface);border-bottom:1px solid var(--line)}
.topbar__inner{max-width:1200px;margin:0 auto;padding:12px 24px;display:flex;align-items:center;gap:16px}
.icon-btn{width:38px;height:38px;display:grid;place-items:center;border:1px solid var(--line);
  background:var(--surface);color:var(--ink-soft);border-radius:var(--radius-sm);cursor:pointer;flex-shrink:0}
.icon-btn:hover{background:var(--primario-tint-2)}
.brand{display:flex;align-items:center;gap:10px;color:var(--ink);flex-shrink:0}
.crest{width:36px;height:36px;border-radius:var(--radius-sm);background:var(--primario);color:#fff;display:grid;place-items:center}
.brand__name{font-weight:700;font-size:15px;line-height:1.1}
.brand__sub{font-size:11.5px;color:var(--muted);font-weight:600}
.context-switch{display:flex;align-items:center;gap:8px;flex-shrink:0;white-space:nowrap;min-width:0}
.context-switch__label{font-size:12.5px;color:var(--ink-soft);font-weight:600;white-space:nowrap;flex-shrink:0}
.topbar__spacer{flex:1}
.user-menu{position:relative;flex-shrink:0}
.user{display:flex;align-items:center;gap:9px;background:var(--surface);border:1px solid var(--line);
  border-radius:999px;padding:4px 12px 4px 4px;cursor:pointer;font:inherit;color:var(--ink);max-width:230px}
.user:hover{background:var(--primario-tint-2)}
.user > span:nth-child(2){white-space:nowrap;overflow:hidden;text-overflow:ellipsis;font-size:13.5px;font-weight:600}
.avatar{width:30px;height:30px;border-radius:50%;background:var(--primario);color:#fff;display:grid;
  place-items:center;font-size:12px;font-weight:700;flex-shrink:0}
.user__caret{transition:transform .2s var(--ease);flex-shrink:0;color:var(--muted)}
.user-menu.is-open .user__caret{transform:rotate(180deg)}
.user-menu__panel{position:absolute;right:0;top:calc(100% + 8px);width:262px;background:var(--surface);
  border:1px solid var(--line);border-radius:var(--radius);box-shadow:var(--shadow-hover);padding:8px;
  display:none;z-index:60}
.user-menu.is-open .user-menu__panel{display:block}
.user-menu__header{display:flex;gap:10px;align-items:center;padding:8px 8px 12px}
.user-menu__name{font-weight:700;font-size:14px}
.user-menu__email{font-size:12px;color:var(--muted);word-break:break-all}
.user-menu__divider{height:1px;background:var(--line);margin:4px 0}
.user-menu__item{display:flex;align-items:center;gap:9px;width:100%;padding:9px 10px;border:0;background:transparent;
  font:inherit;font-size:13.5px;color:var(--ink);border-radius:var(--radius-sm);cursor:pointer;text-align:left}
.user-menu__item:hover{background:var(--primario-tint-2)}
.user-menu__item--danger{color:var(--danger)}
.user-menu__item--danger:hover{background:var(--danger-tint)}

/* ---------- página ---------- */
.wrap{max-width:1200px;margin:0 auto;padding:28px 24px 90px}
.crumb{font-size:12.5px;color:var(--muted);margin-bottom:14px;display:flex;gap:7px;align-items:center}
.crumb .here{color:var(--ink-soft);font-weight:600}
.head{display:flex;justify-content:space-between;align-items:flex-start;gap:24px;margin-bottom:26px;flex-wrap:wrap}
.head h1{font-size:clamp(1.9rem,4vw,2.5rem);line-height:1.1;margin:0 0 8px;font-weight:800;letter-spacing:-.02em}
.head h1 em{color:var(--primario);font-style:normal}
.head p{margin:0;color:var(--ink-soft);font-size:14.5px;max-width:66ch}
.search{display:flex;align-items:center;gap:8px;background:var(--surface);border:1px solid var(--line);
  border-radius:999px;padding:8px 15px;color:var(--muted);min-width:260px}
.search input{border:0;outline:0;background:transparent;font:inherit;font-size:13.5px;color:var(--ink);width:100%}
.section-label{display:flex;align-items:center;gap:14px;margin:0 0 14px}
.section-label h2{font-size:1rem;margin:0;font-weight:700}
.section-label .rule{flex:1;height:1px;background:var(--line)}
.section-label .count{font-size:12.5px;color:var(--muted);font-weight:600}

/* ---------- botones ---------- */
.btn{display:inline-flex;align-items:center;gap:7px;border:1px solid transparent;border-radius:var(--radius-sm);
  padding:10px 18px;font:inherit;font-size:14px;font-weight:600;cursor:pointer;transition:all .2s var(--ease)}
.btn--sm{padding:7px 14px;font-size:13px}
.btn--primario{background:var(--primario);color:#fff}
.btn--primario:hover{background:var(--primario-deep)}
.btn--secundario{background:transparent;color:var(--ink-soft);border-color:var(--line)}
.btn--secundario:hover{background:var(--primario-tint-2)}
.btn--muted{background:var(--primario-tint-2);color:var(--ink-soft);border-color:var(--line)}
.btn--muted:hover{background:var(--primario-tint)}
.btn--danger{background:var(--danger);color:#fff}

/* ---------- toolbar ---------- */
.crud-toolbar{display:flex;justify-content:space-between;gap:14px;flex-wrap:wrap;margin-bottom:14px}
.crud-toolbar__left,.crud-toolbar__right{display:flex;align-items:center;gap:10px;flex-wrap:wrap}

/* ---------- badges ---------- */
.badge{display:inline-flex;align-items:center;gap:6px;border-radius:999px;padding:4px 11px;
  font-size:12px;font-weight:700;background:var(--primario-tint);color:var(--ink)}
.badge--sm{font-size:11.5px;padding:3px 9px}
.badge--tint-neutral{background:var(--line);color:var(--ink-soft)}
.badge--tint-success{background:var(--success-tint);color:var(--ink)}
.badge--tint-warning{background:var(--warning-tint);color:var(--ink)}
.badge--tint-danger{background:var(--danger-tint);color:var(--ink)}
.badge__dot{width:7px;height:7px;border-radius:50%;background:currentColor;flex-shrink:0}
.badge--tint-success .badge__dot{background:var(--success)}
.badge--tint-warning .badge__dot{background:var(--warning)}
.badge--tint-danger .badge__dot{background:var(--danger)}

/* ---------- código y huella ---------- */
.code{font-family:'JetBrains Mono',ui-monospace,SFMono-Regular,Menlo,monospace;font-size:.86em;
  background:var(--primario-tint-2);color:var(--ink-soft);padding:1px 6px;border-radius:6px;
  border:1px solid var(--line)}
.fingerprint{font-family:'JetBrains Mono',ui-monospace,Menlo,monospace;font-size:11.5px;color:var(--ink-soft);
  background:var(--primario-tint-2);border:1px solid var(--line);border-radius:6px;padding:1px 7px}

/* ---------- tabla ---------- */
.dtable-wrap{background:var(--surface);border:1px solid var(--line);border-radius:var(--radius);
  box-shadow:var(--shadow-sm);overflow:hidden}
.dtable-scroll{overflow-x:auto}
.dtable{width:100%;border-collapse:collapse;font-size:.9rem}
.dtable thead th{text-align:left;font-size:11px;letter-spacing:.07em;text-transform:uppercase;
  color:var(--ink-soft);font-weight:700;padding:13px 18px;background:var(--primario-tint-2);
  border-bottom:1px solid var(--line);white-space:nowrap}
.dtable tbody td{padding:14px 18px;border-bottom:1px solid var(--line);vertical-align:middle}
.dtable tbody tr:last-child td{border-bottom:0}
.dtable tbody tr:hover{background:var(--primario-tint-2)}
.dtable__person{display:flex;gap:12px;align-items:flex-start}
.dtable__avatar{width:34px;height:34px;border-radius:var(--radius-sm);display:grid;place-items:center;flex-shrink:0;
  background:var(--secundario-tint);color:var(--secundario)}
.dtable__avatar--terciario{background:var(--terciario-tint);color:var(--terciario)}
.dtable__name{font-weight:700;font-size:14px;margin-bottom:3px}
.dtable__role{margin-bottom:5px}
.dtable__meta{display:flex;align-items:center;gap:5px}
.dtable__empty{color:var(--muted);font-size:13px}
.dtable__actions{display:flex;gap:6px;justify-content:flex-end}
.dtable__action{width:34px;height:34px;display:grid;place-items:center;border:1px solid var(--line);
  background:var(--surface);color:var(--ink-soft);border-radius:var(--radius-sm);cursor:pointer;transition:all .2s var(--ease)}
.dtable__action:hover{background:var(--primario-tint);color:var(--primario);border-color:var(--primario-tint)}
.dtable__action--sm{width:24px;height:24px;border-color:transparent;background:transparent}
.dtable__action--danger:hover{background:var(--danger-tint);color:var(--danger);border-color:var(--danger-tint)}
.pagination-bar{display:flex;justify-content:space-between;align-items:center;padding:12px 18px;
  border-top:1px solid var(--line);font-size:12.5px;color:var(--muted);flex-wrap:wrap;gap:10px}

/* ---------- estado vacío ---------- */
.msg-state{background:var(--surface);border:1px solid var(--line);border-radius:var(--radius);
  box-shadow:var(--shadow-sm);padding:56px 32px;text-align:center}
.msg-state__ico{width:60px;height:60px;border-radius:50%;background:var(--primario-tint);color:var(--primario);
  display:grid;place-items:center;margin:0 auto 18px}
.msg-state__title{font-weight:700;font-size:1.05rem;margin-bottom:7px}
.msg-state__text{color:var(--ink-soft);font-size:14px;max-width:46ch;margin:0 auto 20px}

/* ---------- panel / formulario ---------- */
.panel{background:var(--surface);border:1px solid var(--line);border-radius:var(--radius);
  box-shadow:var(--shadow-sm);margin-top:30px;overflow:hidden}
.panel-header{padding:20px 26px 0}
.panel-header__title{font-size:1.05rem;font-weight:700;margin:0 0 5px}
.panel-header__subtitle{margin:0;color:var(--ink-soft);font-size:13.5px;max-width:72ch}
.panel-body{padding:22px 26px}
.panel-footer{padding:16px 26px;border-top:1px solid var(--line);display:flex;gap:10px;background:var(--primario-tint-2)}
.panel-footer--right{justify-content:flex-end}
.form-grid{display:grid;gap:18px}
.form-grid--2{grid-template-columns:repeat(auto-fit,minmax(260px,1fr))}
.form-field{display:flex;flex-direction:column;gap:6px;margin-bottom:18px}
.form-grid .form-field{margin-bottom:0}
.form-label{display:flex;align-items:center;gap:6px;font-size:13px;font-weight:700;color:var(--ink-soft)}
.form-label svg{opacity:.65;flex-shrink:0}
.form-label__req{color:var(--danger)}
.input{width:100%;border:1px solid var(--line);background:var(--surface);color:var(--ink);
  border-radius:var(--radius-sm);padding:10px 13px;font:inherit;font-size:14px;transition:border-color .2s var(--ease)}
.input:hover{border-color:var(--muted)}
.input:focus{outline:0;border-color:var(--primario);box-shadow:0 0 0 3px var(--primario-tint)}
.input--select{appearance:none;background-image:url("data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 24 24' fill='none' stroke='%2371857f' stroke-width='2' stroke-linecap='round'><polyline points='6 9 12 15 18 9'/></svg>");
  background-repeat:no-repeat;background-position:right 12px center;padding-right:38px}
.form-hint{font-size:12.5px;color:var(--ink-soft)}
.form-hint--danger{color:var(--danger);font-weight:600}
.file-field{display:flex;align-items:center;gap:12px;border:1px dashed var(--line);border-radius:var(--radius-sm);
  padding:12px 14px;background:var(--primario-tint-2)}
.file-field__input{position:absolute;width:1px;height:1px;overflow:hidden;clip:rect(0,0,0,0)}
.file-field__name{font-size:13px;color:var(--muted)}
.file-field__name.is-set{color:var(--ink);font-weight:600}

/* ---------- modal ---------- */
.modal-overlay{position:fixed;inset:0;background:rgba(13,38,34,.45);display:grid;place-items:center;
  z-index:900;padding:24px;opacity:0;pointer-events:none;transition:opacity .45s var(--ease)}
.modal-overlay.is-open{opacity:1;pointer-events:auto}
.modal{background:var(--surface);border-radius:var(--radius);box-shadow:var(--shadow-hover);
  width:min(520px,100%);overflow:hidden}
.modal__header{padding:22px 26px 0;display:flex;gap:14px}
.modal__ico{width:42px;height:42px;border-radius:var(--radius-sm);background:var(--danger-tint);color:var(--danger);
  display:grid;place-items:center;flex-shrink:0}
.modal__title{font-size:1.05rem;font-weight:700;margin:0 0 4px}
.modal__body{padding:14px 26px 22px;font-size:14px;color:var(--ink-soft)}
.modal__list{margin:14px 0 0;padding:12px 16px;background:var(--warning-tint);border-radius:var(--radius-sm);
  color:var(--ink);font-size:13.5px}
.modal__list ul{margin:6px 0 0;padding-left:18px}
.modal__footer{padding:16px 26px;background:var(--primario-tint-2);border-top:1px solid var(--line);
  display:flex;justify-content:flex-end;gap:10px}
[hidden]{display:none!important}
@media (max-width:820px){ .hide-mobile{display:none} .context-switch__label{display:none} }
@media (prefers-reduced-motion:reduce){ *{transition:none!important;animation:none!important} }
</style>
</head>
<body>

<div class="demo">
  <span>Controles de la maqueta —</span>
  <button type="button" id="d-tema">Tema oscuro</button>
  <button type="button" id="d-datos" aria-pressed="true">Con datos</button>
  <button type="button" id="d-vacio" aria-pressed="false">Estado vacío</button>
  <button type="button" id="d-modal">Ver confirmación de revocación</button>
</div>

<header class="topbar">
  <div class="topbar__inner">
    <button class="icon-btn" type="button" aria-label="Abrir menú">
      <svg width="19" height="19" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><line x1="3" y1="6" x2="21" y2="6"/><line x1="3" y1="12" x2="21" y2="12"/><line x1="3" y1="18" x2="21" y2="18"/></svg>
    </button>

    <a class="brand" href="#">
      <span class="crest"><svg width="19" height="19" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M18 8h1a4 4 0 0 1 0 8h-1"/><path d="M2 8h16v9a4 4 0 0 1-4 4H6a4 4 0 0 1-4-4Z"/><line x1="6" y1="1" x2="6" y2="4"/><line x1="10" y1="1" x2="10" y2="4"/><line x1="14" y1="1" x2="14" y2="4"/></svg></span>
      <span>
        <div class="brand__name">NgPushDispatch</div>
        <div class="brand__sub">Panel de administración</div>
      </span>
    </a>

    <div class="context-switch">
      <span class="context-switch__label">Aplicación</span>
      <select class="input input--select" style="width:250px;padding-top:7px;padding-bottom:7px;font-size:13.5px" aria-label="Aplicación en contexto">
        <option>GDA Mi Tresa Ciudadano</option>
        <option>GDA Inspectores</option>
      </select>
    </div>

    <div class="topbar__spacer"></div>

    <div class="user-menu" id="um">
      <button class="user" type="button" aria-haspopup="true" aria-expanded="false" aria-controls="user-panel">
        <span class="avatar" aria-hidden="true">FR</span>
        <span title="fernando rafael filipuzzi">fernando rafael filipuzzi</span>
        <svg class="user__caret" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><polyline points="6 9 12 15 18 9"/></svg>
      </button>
      <div class="user-menu__panel" id="user-panel">
        <div class="user-menu__header">
          <div class="avatar" aria-hidden="true">FR</div>
          <div>
            <div class="user-menu__name">fernando rafael filipuzzi</div>
            <div class="user-menu__email">fernandofilipuzzi.ng@gmail.com</div>
          </div>
        </div>
        <div class="user-menu__divider"></div>
        <a href="#" class="user-menu__item">Mi perfil</a>
        <a href="#" class="user-menu__item">Cambiar contraseña</a>
        <button id="theme-toggle-btn" class="user-menu__item" type="button">
          <svg class="icon-moon" width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"/></svg>
          <svg class="icon-sun" width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" style="display:none" aria-hidden="true"><circle cx="12" cy="12" r="5"/><path d="M12 1v2M12 21v2M4.2 4.2l1.4 1.4M18.4 18.4l1.4 1.4M1 12h2M21 12h2M4.2 19.8l1.4-1.4M18.4 5.6l1.4-1.4"/></svg>
          <span class="theme-toggle__label">Modo oscuro</span>
        </button>
        <div class="user-menu__divider"></div>
        <button class="user-menu__item user-menu__item--danger" type="button">Cerrar sesión</button>
      </div>
    </div>
  </div>
</header>

<main class="wrap">

  <nav class="crumb" aria-label="Miga de pan">
    <a href="#">Inicio</a><span aria-hidden="true">/</span>
    <a href="#">Administración</a><span aria-hidden="true">/</span>
    <span class="here" aria-current="page">Credenciales de proveedor</span>
  </nav>

  <div class="head">
    <div>
      <h1>Credenciales <em>de proveedor</em></h1>
      <p>El material con el que el servicio entrega a APNs y a FCM. Se guarda cifrado y no vuelve a mostrarse, ni siquiera a quien lo cargó. Las credenciales de API viven en la ficha de cada aplicación.</p>
    </div>
    <label class="search">
      <span class="visually-hidden">Buscar credencial</span>
      <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><circle cx="11" cy="11" r="7"/><path d="m21 21-4.3-4.3"/></svg>
      <input type="search" placeholder="Buscar por nombre o huella…">
    </label>
  </div>

  <div class="section-label">
    <h2>Cargadas</h2>
    <span class="rule" aria-hidden="true"></span>
    <span class="count" id="count">3 credenciales · 1 vence este año</span>
  </div>

  <div class="crud-toolbar" id="toolbar">
    <div class="crud-toolbar__left">
      <span class="badge badge--tint-neutral badge--sm">3 activas</span>
      <span class="badge badge--tint-warning badge--sm"><span class="badge__dot" aria-hidden="true"></span>1 vence en 5 meses</span>
    </div>
    <div class="crud-toolbar__right">
      <select class="input input--select" style="width:auto;padding-top:7px;padding-bottom:7px;font-size:13px" aria-label="Filtrar por estado">
        <option>Activas</option><option>Revocadas</option><option>Todas</option>
      </select>
      <button class="btn btn--primario btn--sm" type="button">
        <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><line x1="12" y1="5" x2="12" y2="19"/><line x1="5" y1="12" x2="19" y2="12"/></svg>
        Cargar credencial
      </button>
    </div>
  </div>

  <!-- ============ listado con datos ============ -->
  <div id="vista-datos">
  <div class="dtable-wrap">
    <div class="dtable-scroll">
      <table class="dtable">
        <caption class="visually-hidden">Credenciales de proveedor cargadas</caption>
        <thead>
          <tr>
            <th scope="col">Credencial</th>
            <th scope="col" class="hide-mobile">Identificadores</th>
            <th scope="col">Vigencia</th>
            <th scope="col">Uso</th>
            <th scope="col">Estado</th>
            <th scope="col" style="text-align:right">Acciones</th>
          </tr>
        </thead>
        <tbody>

          <tr>
            <td>
              <div class="dtable__person">
                <div class="dtable__avatar dtable__avatar--terciario" aria-hidden="true">
                  <svg width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 2a10 10 0 0 0-3.2 19.5c.5.1.7-.2.7-.5v-1.7c-2.8.6-3.4-1.4-3.4-1.4-.4-1.2-1.1-1.5-1.1-1.5-.9-.6.1-.6.1-.6 1 .1 1.5 1 1.5 1 .9 1.5 2.3 1.1 2.9.8 0-.7.3-1.1.6-1.4-2.2-.2-4.6-1.1-4.6-5 0-1.1.4-2 1-2.7-.1-.3-.4-1.3.1-2.6 0 0 .8-.3 2.7 1a9.3 9.3 0 0 1 5 0c1.9-1.3 2.7-1 2.7-1 .5 1.3.2 2.3.1 2.6.6.7 1 1.6 1 2.7 0 3.9-2.4 4.8-4.6 5 .3.3.7 1 .7 2v2.9c0 .3.2.6.7.5A10 10 0 0 0 12 2z"/></svg>
                </div>
                <div>
                  <div class="dtable__name">Firebase onesignal-f9a9a</div>
                  <div class="dtable__role"><span class="badge badge--tint-neutral badge--sm">FCM · cuenta de servicio</span></div>
                  <div class="dtable__meta">
                    <span class="fingerprint" title="Huella SHA-256: 5BCED836FF9EF744">5BCE…F744</span>
                    <button class="dtable__action dtable__action--sm" type="button" aria-label="Copiar la huella de Firebase onesignal-f9a9a">
                      <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><rect x="9" y="9" width="13" height="13" rx="2"/><path d="M5 15H4a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h9a2 2 0 0 1 2 2v1"/></svg>
                    </button>
                  </div>
                </div>
              </div>
            </td>
            <td class="hide-mobile"><span class="code">onesignal-f9a9a</span></td>
            <td><span class="dtable__empty">No vence</span></td>
            <td><a href="#">2 aplicaciones</a></td>
            <td><span class="badge badge--tint-success badge--sm"><span class="badge__dot" aria-hidden="true"></span>Activa</span></td>
            <td>
              <div class="dtable__actions">
                <button class="dtable__action" type="button" aria-label="Ver el detalle de Firebase onesignal-f9a9a"><svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/></svg></button>
                <button class="dtable__action dtable__action--danger js-revocar" type="button" aria-label="Revocar Firebase onesignal-f9a9a"><svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><circle cx="12" cy="12" r="9"/><line x1="6" y1="6" x2="18" y2="18"/></svg></button>
              </div>
            </td>
          </tr>

          <tr>
            <td>
              <div class="dtable__person">
                <div class="dtable__avatar" aria-hidden="true">
                  <svg width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 2a4 4 0 0 0-4 4v3H6a1 1 0 0 0-1 1v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V10a1 1 0 0 0-1-1h-2V6a4 4 0 0 0-4-4z"/></svg>
                </div>
                <div>
                  <div class="dtable__name">MiTresa APNs 2027</div>
                  <div class="dtable__role"><span class="badge badge--tint-neutral badge--sm">APNs · certificado .p12</span></div>
                  <div class="dtable__meta">
                    <span class="fingerprint" title="Huella SHA-256: 178B3D2E3876A882">178B…A882</span>
                    <button class="dtable__action dtable__action--sm" type="button" aria-label="Copiar la huella de MiTresa APNs 2027">
                      <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><rect x="9" y="9" width="13" height="13" rx="2"/><path d="M5 15H4a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h9a2 2 0 0 1 2 2v1"/></svg>
                    </button>
                  </div>
                </div>
              </div>
            </td>
            <td class="hide-mobile"><span class="dtable__empty">Sin identificadores</span></td>
            <td><span class="badge badge--tint-warning badge--sm"><span class="badge__dot" aria-hidden="true"></span>Vence el 06/02/2027</span></td>
            <td><a href="#">1 aplicación</a></td>
            <td><span class="badge badge--tint-success badge--sm"><span class="badge__dot" aria-hidden="true"></span>Activa</span></td>
            <td>
              <div class="dtable__actions">
                <button class="dtable__action" type="button" aria-label="Ver el detalle de MiTresa APNs 2027"><svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/></svg></button>
                <button class="dtable__action dtable__action--danger js-revocar" type="button" aria-label="Revocar MiTresa APNs 2027"><svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><circle cx="12" cy="12" r="9"/><line x1="6" y1="6" x2="18" y2="18"/></svg></button>
              </div>
            </td>
          </tr>

          <tr>
            <td>
              <div class="dtable__person">
                <div class="dtable__avatar" aria-hidden="true">
                  <svg width="17" height="17" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M12 2a4 4 0 0 0-4 4v3H6a1 1 0 0 0-1 1v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V10a1 1 0 0 0-1-1h-2V6a4 4 0 0 0-4-4z"/></svg>
                </div>
                <div>
                  <div class="dtable__name">ZZ-prueba-ux-pv</div>
                  <div class="dtable__role"><span class="badge badge--tint-neutral badge--sm">APNs · clave .p8</span></div>
                  <div class="dtable__meta">
                    <span class="fingerprint" title="Huella SHA-256: 4D69818BD3977BEA">4D69…7BEA</span>
                    <button class="dtable__action dtable__action--sm" type="button" aria-label="Copiar la huella de ZZ-prueba-ux-pv">
                      <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><rect x="9" y="9" width="13" height="13" rx="2"/><path d="M5 15H4a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h9a2 2 0 0 1 2 2v1"/></svg>
                    </button>
                  </div>
                </div>
              </div>
            </td>
            <td class="hide-mobile"><span class="code">Key ABC123</span> · <span class="code">Team XYZ789</span></td>
            <td><span class="dtable__empty">No vence</span></td>
            <td><span class="badge badge--tint-neutral badge--sm">Sin uso</span></td>
            <td><span class="badge badge--tint-success badge--sm"><span class="badge__dot" aria-hidden="true"></span>Activa</span></td>
            <td>
              <div class="dtable__actions">
                <button class="dtable__action" type="button" aria-label="Ver el detalle de ZZ-prueba-ux-pv"><svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/></svg></button>
                <button class="dtable__action dtable__action--danger js-revocar" type="button" aria-label="Revocar ZZ-prueba-ux-pv"><svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><circle cx="12" cy="12" r="9"/><line x1="6" y1="6" x2="18" y2="18"/></svg></button>
              </div>
            </td>
          </tr>

        </tbody>
      </table>
    </div>
    <div class="pagination-bar">
      <span>Mostrando <b>1–3</b> de <b>3</b></span>
      <span>Ordenado por vencimiento más próximo</span>
    </div>
  </div>
  </div>

  <!-- ============ estado vacío ============ -->
  <div id="vista-vacio" hidden>
    <div class="msg-state msg-state--empty">
      <div class="msg-state__ico" aria-hidden="true">
        <svg width="26" height="26" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.7" stroke-linecap="round" stroke-linejoin="round"><path d="M12 2a4 4 0 0 0-4 4v3H6a1 1 0 0 0-1 1v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V10a1 1 0 0 0-1-1h-2V6a4 4 0 0 0-4-4z"/></svg>
      </div>
      <div class="msg-state__title">Todavía no hay credenciales cargadas</div>
      <div class="msg-state__text">Sin una credencial de APNs o de FCM el servicio no puede entregar notificaciones. Cargá la primera para empezar.</div>
      <button class="btn btn--primario" type="button">Cargar credencial</button>
    </div>
  </div>

  <!-- ============ alta ============ -->
  <div class="panel">
    <div class="panel-header">
      <h3 class="panel-header__title">Cargar credencial</h3>
      <p class="panel-header__subtitle">El archivo se cifra al guardarse y no vuelve a mostrarse. Vas a poder verificarlo por su huella.</p>
    </div>

    <div class="panel-body">
      <div class="form-grid form-grid--2" style="margin-bottom:18px">
        <div class="form-field">
          <label class="form-label" for="tipo">
            <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><path d="M4 7V4h16v3M9 20h6M12 4v16"/></svg>
            Tipo <span class="form-label__req" aria-hidden="true">*</span>
          </label>
          <select class="input input--select" id="tipo" aria-describedby="h-tipo">
            <option value="p8" selected>APNs · clave .p8 (una por equipo)</option>
            <option value="p12">APNs · certificado .p12 (uno por bundle)</option>
            <option value="fcm">FCM · cuenta de servicio (una por proyecto)</option>
          </select>
          <span class="form-hint" id="h-tipo">Define qué datos hacen falta abajo.</span>
        </div>

        <div class="form-field">
          <label class="form-label" for="nombre">
            <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><path d="M4 7V4h16v3M9 20h6M12 4v16"/></svg>
            Nombre <span class="form-label__req" aria-hidden="true">*</span>
          </label>
          <input class="input" id="nombre" type="text" placeholder="MiTresa APNs 2027" aria-describedby="h-nombre">
          <span class="form-hint" id="h-nombre">Cómo la vas a reconocer en el listado.</span>
        </div>
      </div>

      <div class="form-field">
        <label class="form-label" for="material">
          <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/><polyline points="17 8 12 3 7 8"/><line x1="12" y1="3" x2="12" y2="15"/></svg>
          Material <span class="form-label__req" aria-hidden="true">*</span>
        </label>
        <div class="file-field">
          <input class="file-field__input" id="material" type="file" accept=".p8" aria-describedby="h-material">
          <label class="btn btn--muted btn--sm" for="material" style="cursor:pointer">Elegir archivo…</label>
          <span class="file-field__name" id="fname">Ningún archivo elegido</span>
        </div>
        <span class="form-hint" id="h-material">Archivo <span class="code" id="ext">.p8</span> descargado de la consola de Apple. Máximo 64 KB.</span>
      </div>

      <!-- bloque condicional -->
      <div class="form-grid form-grid--2" data-caso="p8">
        <div class="form-field">
          <label class="form-label" for="keyid"><svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><circle cx="8" cy="15" r="4"/><path d="m10.8 12.2 8.2-8.2M17 6l2 2M15 8l2 2"/></svg>Key ID <span class="form-label__req" aria-hidden="true">*</span></label>
          <input class="input" id="keyid" type="text" placeholder="ABC123DEFG" aria-describedby="h-keyid">
          <span class="form-hint" id="h-keyid">Diez caracteres, en el nombre del archivo descargado.</span>
        </div>
        <div class="form-field">
          <label class="form-label" for="teamid"><svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/></svg>Team ID <span class="form-label__req" aria-hidden="true">*</span></label>
          <input class="input" id="teamid" type="text" placeholder="XYZ789HIJK">
        </div>
      </div>

      <div class="form-grid form-grid--2" data-caso="p12" hidden>
        <div class="form-field">
          <label class="form-label" for="pass"><svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><rect x="3" y="11" width="18" height="11" rx="2"/><path d="M7 11V7a5 5 0 0 1 10 0v4"/></svg>Contraseña del certificado <span class="form-label__req" aria-hidden="true">*</span></label>
          <input class="input" id="pass" type="password" placeholder="••••••••" aria-describedby="h-pass">
          <span class="form-hint" id="h-pass">Se usa para abrir el <span class="code">.p12</span> y no se guarda.</span>
        </div>
        <div class="form-field">
          <label class="form-label" for="vence"><svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" aria-hidden="true"><rect x="3" y="4" width="18" height="18" rx="2"/><line x1="3" y1="10" x2="21" y2="10"/></svg>Vence el</label>
          <input class="input" id="vence" type="date">
          <span class="form-hint">Se autocompleta si el certificado lo declara.</span>
        </div>
      </div>

      <div data-caso="fcm" hidden>
        <div class="form-field" style="margin-bottom:0">
          <span class="form-label">Detectado en el archivo</span>
          <div style="display:flex;gap:10px;flex-wrap:wrap;padding:13px 15px;background:var(--primario-tint-2);border:1px solid var(--line);border-radius:var(--radius-sm)">
            <span class="dtable__empty">Elegí el JSON y acá te muestro el proyecto y la cuenta antes de guardar.</span>
          </div>
          <span class="form-hint">No hace falta que escribas nada: <span class="code">project_id</span> y <span class="code">client_email</span> se leen del archivo.</span>
        </div>
      </div>
    </div>

    <div class="panel-footer panel-footer--right">
      <button class="btn btn--secundario" type="button">Cancelar</button>
      <button class="btn btn--primario" type="submit">Cargar y cifrar</button>
    </div>
  </div>

</main>

<!-- ============ modal de revocación ============ -->
<div class="modal-overlay" id="m-revocar" role="dialog" aria-modal="true" aria-labelledby="m-titulo" hidden>
  <div class="modal">
    <div class="modal__header">
      <div class="modal__ico" aria-hidden="true">
        <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round"><path d="M10.3 3.9 1.8 18a2 2 0 0 0 1.7 3h17a2 2 0 0 0 1.7-3L13.7 3.9a2 2 0 0 0-3.4 0z"/><line x1="12" y1="9" x2="12" y2="13"/><line x1="12" y1="17" x2="12.01" y2="17"/></svg>
      </div>
      <div>
        <h2 class="modal__title" id="m-titulo">Revocar «Firebase onesignal-f9a9a»</h2>
        <p style="margin:0;font-size:13px;color:var(--muted)">Esta acción no se puede deshacer.</p>
      </div>
    </div>
    <div class="modal__body">
      La credencial deja de servir de inmediato y el material cifrado se destruye. Para volver a usarla vas a tener que descargarla otra vez de la consola del proveedor.
      <div class="modal__list">
        <b>2 aplicaciones se quedan sin proveedor de envío:</b>
        <ul><li>GDA Mi Tresa Ciudadano</li><li>GDA Inspectores</li></ul>
      </div>
    </div>
    <div class="modal__footer">
      <button class="btn btn--secundario" type="button" id="m-cancelar">Cancelar</button>
      <button class="btn btn--danger" type="button">Revocar</button>
    </div>
  </div>
</div>

<script>
(function(){
  var um = document.getElementById('um'), btn = um.querySelector('.user');
  btn.addEventListener('click', function(e){
    e.stopPropagation();
    var open = um.classList.toggle('is-open');
    btn.setAttribute('aria-expanded', open ? 'true' : 'false');
  });
  document.addEventListener('click', function(){ um.classList.remove('is-open'); btn.setAttribute('aria-expanded','false'); });

  function setTema(dark){
    document.documentElement.setAttribute('data-theme', dark ? 'dark' : '');
    document.querySelector('.icon-moon').style.display = dark ? 'none' : '';
    document.querySelector('.icon-sun').style.display  = dark ? '' : 'none';
    document.querySelector('.theme-toggle__label').textContent = dark ? 'Modo claro' : 'Modo oscuro';
    document.getElementById('d-tema').textContent = dark ? 'Tema claro' : 'Tema oscuro';
  }
  function toggle(){ setTema(document.documentElement.getAttribute('data-theme') !== 'dark'); }
  document.getElementById('theme-toggle-btn').addEventListener('click', function(e){ e.stopPropagation(); toggle(); });
  document.getElementById('d-tema').addEventListener('click', toggle);

  var accept = { p8:'.p8', p12:'.p12', fcm:'.json' };
  document.getElementById('tipo').addEventListener('change', function(){
    var v = this.value;
    document.querySelectorAll('[data-caso]').forEach(function(b){ b.hidden = b.dataset.caso !== v; });
    document.getElementById('material').setAttribute('accept', accept[v]);
    document.getElementById('ext').textContent = accept[v];
    document.getElementById('fname').textContent = 'Ningún archivo elegido';
    document.getElementById('fname').classList.remove('is-set');
  });
  document.getElementById('material').addEventListener('change', function(){
    var n = document.getElementById('fname');
    n.textContent = this.files[0] ? this.files[0].name : 'Ningún archivo elegido';
    n.classList.toggle('is-set', !!this.files[0]);
  });

  var datos = document.getElementById('vista-datos'), vacio = document.getElementById('vista-vacio'),
      bD = document.getElementById('d-datos'), bV = document.getElementById('d-vacio');
  function vista(v){
    datos.hidden = !v; vacio.hidden = v;
    document.getElementById('toolbar').hidden = !v;
    document.getElementById('count').textContent = v ? '3 credenciales · 1 vence este año' : 'ninguna todavía';
    bD.setAttribute('aria-pressed', v ? 'true':'false'); bV.setAttribute('aria-pressed', v ? 'false':'true');
  }
  bD.addEventListener('click', function(){ vista(true); });
  bV.addEventListener('click', function(){ vista(false); });

  var ov = document.getElementById('m-revocar');
  function abrir(){ ov.hidden = false; requestAnimationFrame(function(){ ov.classList.add('is-open'); }); }
  function cerrar(){ ov.classList.remove('is-open'); setTimeout(function(){ ov.hidden = true; }, 450); }
  document.getElementById('d-modal').addEventListener('click', abrir);
  document.querySelectorAll('.js-revocar').forEach(function(b){ b.addEventListener('click', abrir); });
  document.getElementById('m-cancelar').addEventListener('click', cerrar);
  ov.addEventListener('click', function(e){ if(e.target === ov) cerrar(); });
  document.addEventListener('keydown', function(e){ if(e.key === 'Escape' && !ov.hidden) cerrar(); });
})();
</script>
</body>
</html>