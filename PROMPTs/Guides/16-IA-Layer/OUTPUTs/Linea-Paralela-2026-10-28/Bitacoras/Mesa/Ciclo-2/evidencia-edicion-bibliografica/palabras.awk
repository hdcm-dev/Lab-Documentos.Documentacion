/^```/{code=!code; next}
/^## /{if(t)printf "%6d %6d %6d  %s\n", p+c, p, c, t; t=$0; p=0; c=0; next}
{ if(code) c+=NF; else p+=NF }
END{printf "%6d %6d %6d  %s\n", p+c, p, c, t}
