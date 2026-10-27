import re,sys,html
t=open(sys.argv[1],errors='replace').read()
t=re.sub(r'<script.*?</script>|<style.*?</style>','',t,flags=re.S)
t=html.unescape(re.sub(r'<[^>]+>',' ',t)); t=re.sub(r'\s+',' ',t)
for k in sys.argv[2:]:
    for m in list(re.finditer(k,t,re.I))[:2]:
        print('['+k+']', t[max(0,m.start()-200):m.end()+250]); print()
