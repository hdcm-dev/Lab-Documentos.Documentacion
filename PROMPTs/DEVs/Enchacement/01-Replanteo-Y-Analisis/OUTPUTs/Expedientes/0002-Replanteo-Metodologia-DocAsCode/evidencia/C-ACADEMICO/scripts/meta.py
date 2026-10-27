import sys, re, html, pathlib
d = pathlib.Path(sys.argv[1])
keys = ['author','article:author','article:published_time','article:modified_time','og:site_name','og:title','ms.date','ms.author','date','dc.date','last-modified','og:updated_time','citation_date']
for f in sorted(d.glob('R*.html')):
    t = f.read_text(errors='replace')
    ti = re.search(r'<title[^>]*>(.*?)</title>', t, re.S|re.I)
    out = {'title': html.unescape(ti.group(1).strip())[:120] if ti else ''}
    for m in re.finditer(r'<meta\s+[^>]*>', t, re.I):
        tag = m.group(0)
        n = re.search(r'(?:name|property)\s*=\s*"([^"]+)"', tag, re.I)
        c = re.search(r'content\s*=\s*"([^"]*)"', tag, re.I)
        if n and c and n.group(1).lower() in keys:
            out[n.group(1).lower()] = html.unescape(c.group(1))[:80]
    # visible date hints
    lu = re.findall(r'(?:Last updated|Updated|last_modified|dateModified|datePublished)["\s:>]*([A-Za-z0-9 ,:\-T\.]{6,30})', t)
    if lu: out['hint'] = lu[0][:40]
    print(f.stem, '|', ' | '.join(f'{k}={v}' for k,v in out.items()))
