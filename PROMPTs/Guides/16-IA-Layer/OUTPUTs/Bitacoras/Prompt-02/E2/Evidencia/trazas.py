import re,sys
T=open(sys.argv[1],encoding='utf-8').read()
ids=set(re.findall(r'<a id="([^"]+)"',T))
refs=set(re.findall(r'^- \[(REF-\d+)\]',T,re.M))
P={
'P-1':(['s3-1','s4-4','s13-2'],['REF-182','REF-183']),
'P-2':(['s5-6','s13-3'],['REF-44','REF-45']),
'P-3':(['s12-4','s13-4'],['REF-55']),
'P-4':(['s3-2','s6-1','s13-5'],['REF-86','REF-87']),
'P-5':(['s3-1','s7-3','s13-6'],['REF-89','REF-102']),
'P-6':(['s8-4','s8-5','s11-2','s13-7'],['REF-122','REF-160','REF-162']),
'P-7':(['s3-2','s8-1','s13-8'],['REF-115','REF-117']),
'P-8':(['s2-5','s5-3','s13-9'],['REF-01','REF-160']),
'P-9':(['s5-4','s12-1','s12-2','s13-10'],['REF-173','REF-192']),
'P-10':(['s0-4','s10-1','s13-11'],['REF-75','REF-152']),
}
fallas=0
for p,(a,r) in P.items():
    ma=[x for x in a if x not in ids]; mr=[x for x in r if x not in refs]
    fallas+=len(ma)+len(mr)
    print(p,'anclas',len(a)-len(ma),'/',len(a),'refs',len(r)-len(mr),'/',len(r),'faltan',ma+mr)
print('fallas',fallas); sys.exit(1 if fallas else 0)
