import re, sys, html, pathlib
d = pathlib.Path(sys.argv[1])
Q = [
 ("R03","A push to the production branch triggers a deployment"),
 ("R03","find broken links, check accessibility, validate OpenAPI specs"),
 ("R04","Reference any number of OpenAPI specifications in the navigation element of your docs.json to create pages for your API endpoints"),
 ("R04","Generated endpoint pages have these default metadata values"),
 ("R05","Documentation as Code (Docs as Code) refers to a philosophy that you should be writing documentation with the same tools as code"),
 ("R05","following the same workflows as development teams, and being integrated in the product team"),
 ("R06","four distinct needs, and four corresponding forms of documentation - tutorials, how-to guides, technical reference and explanation"),
 ("R07","an open source framework for building developer portals"),
 ("R08","homegrown docs-like-code solution"),
 ("R08","Engineers write their documentation in Markdown files which live together with their code"),
 ("R08","from the Service's page in Backstage Catalog"),
 ("R09","Users must belong to at least one of the listed groups to access the page"),
 ("R09","they'll receive a 404 error"),
 ("R10","in the project repository under doc/arch/adr-NNN.md"),
 ("R10","a conversation with a future developer"),
 ("R13","groups control visibility but do not restrict access to a page"),
 ("R13","Use authentication to restrict access to sensitive content"),
 ("R14","Most of the time, you don't need versioning as it will just increase your build time, and introduce complexity to your codebase"),
 ("R14","linking to immutable standalone deployment"),
 ("R15","isn't an infallible way to detect the user's preferred language"),
 ("R15","a production app should include a way for a user to customize their choice of culture"),
 ("R15","Generally, only localize text, not HTML"),
 ("R15","if not found, it reverts to the parent culture"),
 ("R17","the last time the article was substantially edited or guaranteed fresh"),
 ("R17","Identifies the article's owner"),
 ("R18","Keep an Unreleased section at the top to track upcoming changes"),
 ("R18","for soon-to-be removed features"),
 ("R19","Static site generator for .NET API documentation"),
 ("R20","A fast, powerful, CommonMark compliant, extensible Markdown processor for .NET"),
]
def norm(s):
    s = html.unescape(s)
    s = s.replace('’',"'").replace('‘',"'").replace('“','"').replace('”','"').replace('–','-').replace('—','-').replace('`','')
    return re.sub(r'\s+',' ',s).lower()
cache = {}
ok = 0
for rid, q in Q:
    if rid not in cache:
        t = (d/f'{rid}.html').read_text(errors='replace')
        t2 = re.sub(r'<[^>]+>',' ',t)
        cache[rid] = norm(t2) + ' || ' + norm(t)
    hit = norm(q) in cache[rid]
    ok += hit
    print(f'{rid}\t{"SI" if hit else "NO"}\t{q}')
print(f'TOTAL {ok}/{len(Q)}')
