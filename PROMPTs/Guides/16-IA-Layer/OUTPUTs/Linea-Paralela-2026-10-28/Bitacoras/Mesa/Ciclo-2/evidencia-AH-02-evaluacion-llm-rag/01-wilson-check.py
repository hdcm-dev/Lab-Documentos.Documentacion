import re, sys, math
z=1.959964
def wilson(k,n):
    p=k/n; d=1+z*z/n; c=(p+z*z/(2*n))/d; h=z*math.sqrt(p*(1-p)/n+z*z/(4*n*n))/d
    return max(0,c-h), min(1,c+h)
txt=open(sys.argv[1],encoding='utf-8').read()
lines=txt.split('\n')
pat=re.compile(r'(\d+)\s*(?:/|de)\s*(\d+)[^\[\n]{0,80}?\[\s*([01](?:,\d+)?)\s*;\s*([01](?:,\d+)?)\s*\]')
bad=0; tot=0
for i,l in enumerate(lines,1):
    for m in pat.finditer(l):
        k,n=int(m.group(1)),int(m.group(2))
        if n==0 or k>n or n>200: continue
        a=float(m.group(3).replace(',','.')); b=float(m.group(4).replace(',','.'))
        lo,hi=wilson(k,n); tot+=1
        dec=max(len(m.group(3).split(',')[-1]) if ',' in m.group(3) else 0, len(m.group(4).split(',')[-1]) if ',' in m.group(4) else 0, 2)
        ok = abs(round(lo,2)-a)<=0.011 and abs(round(hi,2)-b)<=0.011
        if not ok:
            bad+=1; print(f"L{i}: {k}/{n} dice [{a};{b}] Wilson [{lo:.3f};{hi:.3f}] :: {m.group(0)[:100]}")
print(f"revisados {tot}, discrepancias {bad}")
