gnuplot -persist << END
#set terminal x11 0
#p "dat" u 1:2 w l, "" u 1:3 w l, "" u 1:4 w l, "" u 1:5 w l, "" u 1:7 w l, "" u 1:8 w l
#set terminal x11 1
#p "dat" u 1:(\$3-\$2) w l, "" u 1:(\$4-\$2) w l, "" u 1:(\$5-\$2) w l
#set terminal x11 2
#p "dat" u 1:6 w l, "" u 1:7 w l
#set terminal x11 3
#p "dat" u 1:(\$2-\$7) w l, "" u 1:(\$3-\$7) w l, "" u 1:(\$4-\$7) w l, "" u 1:(\$5-\$7) w l, "" u 1:(\$8-\$7) w l
#set terminal x11 4
p "dat" u 1:7 title "Analytical", \
"" u 1:2 w l title "Explicit Euler",\
"" u 1:4 w l title "O(1.5) strong"
#set terminal x11
#p "dat" u 1:(\$2-\$7) w l title "Explicit Euler",\
#"" u 1:(\$4-\$7) w l title "O(1.5) strong"
END
