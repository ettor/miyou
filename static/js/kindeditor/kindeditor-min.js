/* KindEditor 4.1 (2012-05-12), Copyright (C) kindsoft.net, Licence: http://www.kindsoft.net/license.php */
(function(z, j) {
    function V(a) {
        if (!a) return ! 1;
        return Object.prototype.toString.call(a) === "[object Array]"
    }
    function bb(a) {
        if (!a) return ! 1;
        return Object.prototype.toString.call(a) === "[object Function]"
    }
    function L(a, b) {
        for (var c = 0,
        d = b.length; c < d; c++) if (a === b[c]) return c;
        return - 1
    }
    function m(a, b) {
        if (V(a)) for (var c = 0,
        d = a.length; c < d; c++) {
            if (b.call(a[c], c, a[c]) === !1) break
        } else for (c in a) if (a.hasOwnProperty(c) && b.call(a[c], c, a[c]) === !1) break
    }
    function A(a) {
        return a.replace(/(?:^[ \t\n\r]+)|(?:[ \t\n\r]+$)/g, "")
    }
    function ma(a, b, c) {
        c = c === j ? ",": c;
        return (c + b + c).indexOf(c + a + c) >= 0
    }
    function r(a) {
        return a && /^\d+$/.test(a) ? a + "px": a
    }
    function t(a) {
        var b;
        return a && (b = /(\d+)/.exec(a)) ? parseInt(b[1], 10) : 0
    }
    function C(a) {
        return a.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;")
    }
    function Ea(a) {
        return a.replace(/&lt;/g, "<").replace(/&gt;/g, ">").replace(/&quot;/g, '"').replace(/&amp;/g, "&")
    }
    function ca(a) {
        var b = a.split("-"),
        a = "";
        m(b,
        function(b, d) {
            a += b > 0 ? d.charAt(0).toUpperCase() + d.substr(1) : d
        });
        return a
    }
    function na(a) {
        function b(a) {
            a = parseInt(a, 10).toString(16).toUpperCase();
            return a.length > 1 ? a: "0" + a
        }
        return a.replace(/rgb\s*\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*\)/ig,
        function(a, d, e, g) {
            return "#" + b(d) + b(e) + b(g)
        })
    }
    function u(a, b) {
        var b = b === j ? ",": b,
        c = {},
        d = V(a) ? a: a.split(b),
        e;
        m(d,
        function(a, b) {
            if (e = /^(\d+)\.\.(\d+)$/.exec(b)) for (var d = parseInt(e[1], 10); d <= parseInt(e[2], 10); d++) c[d.toString()] = !0;
            else c[b] = !0
        });
        return c
    }
    function Fa(a, b) {
        return Array.prototype.slice.call(a, b || 0)
    }
    function l(a, b) {
        return a === j ? b: a
    }
    function F(a, b, c) {
        c || (c = b, b = null);
        var d;
        if (b) {
            var e = function() {};
            e.prototype = b.prototype;
            d = new e;
            m(c,
            function(a, b) {
                d[a] = b
            })
        } else d = c;
        d.constructor = a;
        a.prototype = d;
        a.parent = b ? b.prototype: null
    }
    function cb(a) {
        var b;
        if (b = /\{[\s\S]*\}|\[[\s\S]*\]/.exec(a)) a = b[0];
        b = /[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g;
        b.lastIndex = 0;
        b.test(a) && (a = a.replace(b,
        function(a) {
            return "\\u" + ("0000" + a.charCodeAt(0).toString(16)).slice( - 4)
        }));
        if (/^[\],:{}\s]*$/.test(a.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, "@").replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, "]").replace(/(?:^|:|,)(?:\s*\[)+/g, ""))) return eval("(" + a + ")");
        throw "JSON parse error";
    }
    function Qb(a, b, c) {
        a.addEventListener ? a.addEventListener(b, c, db) : a.attachEvent && a.attachEvent("on" + b, c)
    }
    function oa(a, b, c) {
        a.removeEventListener ? a.removeEventListener(b, c, db) : a.detachEvent && a.detachEvent("on" + b, c)
    }
    function eb(a, b) {
        this.init(a, b)
    }
    function fb(a) {
        try {
            delete a[W]
        } catch(b) {
            a.removeAttribute && a.removeAttribute(W)
        }
    }
    function X(a, b, c) {
        if (b.indexOf(",") >= 0) m(b.split(","),
        function() {
            X(a, this, c)
        });
        else {
            var d = a[W] || null;
            d || (a[W] = ++gb, d = gb);
            v[d] === j && (v[d] = {});
            var e = v[d][b];
            e && e.length > 0 ? oa(a, b, e[0]) : (v[d][b] = [], v[d].el = a);
            e = v[d][b];
            e.length === 0 && (e[0] = function(b) {
                var c = b ? new eb(a, b) : j;
                m(e,
                function(b, d) {
                    b > 0 && d && d.call(a, c)
                })
            });
            L(c, e) < 0 && e.push(c);
            Qb(a, b, e[0])
        }
    }
    function da(a, b, c) {
        if (b && b.indexOf(",") >= 0) m(b.split(","),
        function() {
            da(a, this, c)
        });
        else {
            var d = a[W] || null;
            if (d) if (b === j) d in v && (m(v[d],
            function(b, c) {
                b != "el" && c.length > 0 && oa(a, b, c[0])
            }), delete v[d], fb(a));
            else if (v[d]) {
                var e = v[d][b];
                if (e && e.length > 0) {
                    c === j ? (oa(a, b, e[0]), delete v[d][b]) : (m(e,
                    function(a, b) {
                        a > 0 && b === c && e.splice(a, 1)
                    }), e.length == 1 && (oa(a, b, e[0]), delete v[d][b]));
                    var g = 0;
                    m(v[d],
                    function() {
                        g++
                    });
                    g < 2 && (delete v[d], fb(a))
                }
            }
        }
    }
    function hb(a, b) {
        if (b.indexOf(",") >= 0) m(b.split(","),
        function() {
            hb(a, this)
        });
        else {
            var c = a[W] || null;
            if (c) {
                var d = v[c][b];
                if (v[c] && d && d.length > 0) d[0]()
            }
        }
    }
    function Ga(a, b, c) {
        b = /^\d{2,}$/.test(b) ? b: b.toUpperCase().charCodeAt(0);
        X(a, "keydown",
        function(d) {
            d.ctrlKey && d.which == b && !d.shiftKey && !d.altKey && (c.call(a), d.stop())
        })
    }
    function ea(a) {
        for (var b = {},
        c = /\s*([\w\-]+)\s*:([^;]*)(;|$)/g,
        d; d = c.exec(a);) {
            var e = A(d[1].toLowerCase());
            d = A(na(d[2]));
            b[e] = d
        }
        return b
    }
    function J(a) {
        for (var b = {},
        c = /\s+(?:([\w\-:]+)|(?:([\w\-:]+)=([^\s"'<>]+))|(?:([\w\-:"]+)="([^"]*)")|(?:([\w\-:"]+)='([^']*)'))(?=(?:\s|\/|>)+)/g,
        d; d = c.exec(a);) {
            var e = (d[1] || d[2] || d[4] || d[6]).toLowerCase();
            b[e] = (d[2] ? d[3] : d[4] ? d[5] : d[7]) || ""
        }
        return b
    }
    function Rb(a, b) {
        return a = /\s+class\s*=/.test(a) ? a.replace(/(\s+class=["']?)([^"']*)(["']?[\s>])/,
        function(a, d, e, g) {
            return (" " + e + " ").indexOf(" " + b + " ") < 0 ? e === "" ? d + b + g: d + e + " " + b + g: a
        }) : a.substr(0, a.length - 1) + ' class="' + b + '">'
    }
    function Sb(a) {
        var b = "";
        m(ea(a),
        function(a, d) {
            b += a + ":" + d + ";"
        });
        return b
    }
    function pa(a, b, c, d) {
        function e(a) {
            for (var a = a.split("/"), b = [], c = 0, d = a.length; c < d; c++) {
                var e = a[c];
                e == ".." ? b.length > 0 && b.pop() : e !== "" && e != "." && b.push(e)
            }
            return "/" + b.join("/")
        }
        function g(b, c) {
            if (a.substr(0, b.length) === b) {
                for (var e = [], h = 0; h < c; h++) e.push("..");
                h = ".";
                e.length > 0 && (h += "/" + e.join("/"));
                d == "/" && (h += "/");
                return h + a.substr(b.length)
            } else if (f = /^(.*)\//.exec(b)) return g(f[1], ++c)
        }
        b = l(b, "").toLowerCase();
        a = a.replace(/([^:])\/\//g, "$1/");
        if (L(b, ["absolute", "relative", "domain"]) < 0) return a;
        c = c || location.protocol + "//" + location.host;
        if (d === j) var h = location.pathname.match(/^(\/.*)\//),
        d = h ? h[1] : "";
        var f;
        if (f = /^(\w+:\/\/[^\/]*)/.exec(a)) {
            if (f[1] !== c) return a
        } else if (/^\w+:/.test(a)) return a;
        /^\//.test(a) ? a = c + e(a.substr(1)) : /^\w+:\/\//.test(a) || (a = c + e(d + "/" + a));
        b === "relative" ? a = g(c + d, 0).substr(2) : b === "absolute" && a.substr(0, c.length) === c && (a = a.substr(c.length));
        return a
    }
    function Q(a, b, c, d, e) {
        var c = c || "",
        d = l(d, !1),
        e = l(e, "\t"),
        g = "xx-small,x-small,small,medium,large,x-large,xx-large".split(","),
        a = a.replace(/(<(?:pre|pre\s[^>]*)>)([\s\S]*?)(<\/pre>)/ig,
        function(a, b, c, d) {
            return b + c.replace(/<(?:br|br\s[^>]*)>/ig, "\n") + d
        }),
        a = a.replace(/<(?:br|br\s[^>]*)\s*\/?>\s*<\/p>/ig, "</p>"),
        a = a.replace(/(<(?:p|p\s[^>]*)>)\s*(<\/p>)/ig, "$1<br />$2"),
        a = a.replace(/\u200B/g, ""),
        h = {};
        b && (m(b,
        function(a, b) {
            for (var c = a.split(","), d = 0, e = c.length; d < e; d++) h[c[d]] = u(b)
        }), h.script || (a = a.replace(/(<(?:script|script\s[^>]*)>)([\s\S]*?)(<\/script>)/ig, "")), h.style || (a = a.replace(/(<(?:style|style\s[^>]*)>)([\s\S]*?)(<\/style>)/ig, "")));
        var f = [],
        a = a.replace(/([ \t\n\r]*)<(\/)?([\w\-:]+)((?:\s+|(?:\s+[\w\-:]+)|(?:\s+[\w\-:]+=[^\s"'<>]+)|(?:\s+[\w\-:"]+="[^"]*")|(?:\s+[\w\-:"]+='[^']*'))*)(\/)?>([ \t\n\r]*)/g,
        function(a, n, s, q, qa, D, G) {
            var n = n || "",
            s = s || "",
            j = q.toLowerCase(),
            l = qa || "",
            q = D ? " " + D: "",
            G = G || "";
            if (b && !h[j]) return "";
            q === "" && ib[j] && (q = " /");
            jb[j] && (n && (n = " "), G && (G = " "));
            Ha[j] && (s ? G = "\n": n = "\n");
            d && j == "br" && (G = "\n");
            if (kb[j] && !Ha[j]) if (d) {
                s && f.length > 0 && f[f.length - 1] === j ? f.pop() : f.push(j);
                G = n = "\n";
                qa = 0;
                for (D = s ? f.length: f.length - 1; qa < D; qa++) n += e,
                s || (G += e);
                q ? f.pop() : s || (G += e)
            } else n = G = "";
            if (l !== "") {
                var w = J(a);
                if (j === "font") {
                    var o = {},
                    H = "";
                    m(w,
                    function(a, b) {
                        if (a === "color") o.color = b,
                        delete w[a];
                        a === "size" && (o["font-size"] = g[parseInt(b, 10) - 1] || "", delete w[a]);
                        a === "face" && (o["font-family"] = b, delete w[a]);
                        a === "style" && (H = b)
                    });
                    H && !/;$/.test(H) && (H += ";");
                    m(o,
                    function(a, b) {
                        b !== "" && (/\s/.test(b) && (b = "'" + b + "'"), H += a + ":" + b + ";")
                    });
                    w.style = H
                }
                m(w,
                function(a, d) {
                    Tb[a] && (w[a] = a);
                    L(a, ["src", "href"]) >= 0 && (w[a] = pa(d, c)); (b && a !== "style" && !h[j]["*"] && !h[j][a] || j === "body" && a === "contenteditable" || /^kindeditor_\d+$/.test(a)) && delete w[a];
                    if (a === "style" && d !== "") {
                        var e = ea(d);
                        m(e,
                        function(a) {
                            b && !h[j].style && !h[j]["." + a] && delete e[a]
                        });
                        var g = "";
                        m(e,
                        function(a, b) {
                            g += a + ":" + b + ";"
                        });
                        w.style = g
                    }
                });
                l = "";
                m(w,
                function(a, b) {
                    a === "style" && b === "" || (b = b.replace(/"/g, "&quot;"), l += " " + a + '="' + b + '"')
                })
            }
            j === "font" && (j = "span");
            return n + "<" + s + j + l + q + ">" + G
        }),
        a = a.replace(/(<(?:pre|pre\s[^>]*)>)([\s\S]*?)(<\/pre>)/ig,
        function(a, b, c, d) {
            return b + c.replace(/\n/g, '<span id="__kindeditor_pre_newline__">\n') + d
        }),
        a = a.replace(/\n\s*\n/g, "\n"),
        a = a.replace(/<span id="__kindeditor_pre_newline__">\n/g, "\n");
        return A(a)
    }
    function lb(a, b) {
        a = a.replace(/<meta[\s\S]*?>/ig, "").replace(/<![\s\S]*?>/ig, "").replace(/<style[^>]*>[\s\S]*?<\/style>/ig, "").replace(/<script[^>]*>[\s\S]*?<\/script>/ig, "").replace(/<w:[^>]+>[\s\S]*?<\/w:[^>]+>/ig, "").replace(/<o:[^>]+>[\s\S]*?<\/o:[^>]+>/ig, "").replace(/<xml>[\s\S]*?<\/xml>/ig, "").replace(/<(?:table|td)[^>]*>/ig,
        function(a) {
            return a.replace(/border-bottom:([#\w\s]+)/ig, "border:$1")
        });
        return Q(a, b)
    }
    function mb(a) {
        if (/\.(rm|rmvb)(\?|$)/i.test(a)) return "audio/x-pn-realaudio-plugin";
        if (/\.(swf|flv)(\?|$)/i.test(a)) return "application/x-shockwave-flash";
        return "video/x-ms-asf-plugin"
    }
    function nb(a) {
        return J(unescape(a))
    }
    function Ia(a) {
        var b = "<embed ";
        m(a,
        function(a, d) {
            b += a + '="' + d + '" '
        });
        b += "/>";
        return b
    }
    function ob(a, b) {
        var c = b.width,
        d = b.height,
        e = b.type || mb(b.src),
        g = Ia(b),
        h = "";
        c > 0 && (h += "width:" + c + "px;");
        d > 0 && (h += "height:" + d + "px;");
        c = /realaudio/i.test(e) ? "ke-rm": /flash/i.test(e) ? "ke-flash": "ke-media";
        c = '<img class="' + c + '" src="' + a + '" ';
        h !== "" && (c += 'style="' + h + '" ');
        c += 'data-ke-tag="' + escape(g) + '" alt="" />';
        return c
    }
    function sa(a, b) {
        if (a.nodeType == 9 && b.nodeType != 9) return ! 0;
        for (; b = b.parentNode;) if (b == a) return ! 0;
        return ! 1
    }
    function ta(a, b) {
        var b = b.toLowerCase(),
        c = null;
        if (!Ub && a.nodeName.toLowerCase() != "script") {
            var d = a.ownerDocument.createElement("div");
            d.appendChild(a.cloneNode(!1));
            d = J(Ea(d.innerHTML));
            b in d && (c = d[b])
        } else try {
            c = a.getAttribute(b, 2)
        } catch(e) {
            c = a.getAttribute(b, 1)
        }
        b === "style" && c !== null && (c = Sb(c));
        return c
    }
    function ua(a, b) {
        function c(a) {
            if (typeof a != "string") return a;
            return a.replace(/([^\w\-])/g, "\\$1")
        }
        function d(a, b) {
            return a === "*" || a.toLowerCase() === c(b.toLowerCase())
        }
        function e(a, b, c) {
            var e = []; (a = (c.ownerDocument || c).getElementById(a.replace(/\\/g, ""))) && d(b, a.nodeName) && sa(c, a) && e.push(a);
            return e
        }
        function g(a, b, c) {
            var e = c.ownerDocument || c,
            g = [],
            h,
            f,
            i;
            if (c.getElementsByClassName) {
                e = c.getElementsByClassName(a.replace(/\\/g, ""));
                h = 0;
                for (f = e.length; h < f; h++) i = e[h],
                d(b, i.nodeName) && g.push(i)
            } else if (e.querySelectorAll) {
                e = e.querySelectorAll((c.nodeName !== "#document" ? c.nodeName + " ": "") + b + "." + a);
                h = 0;
                for (f = e.length; h < f; h++) i = e[h],
                sa(c, i) && g.push(i)
            } else {
                e = c.getElementsByTagName(b);
                a = " " + a + " ";
                h = 0;
                for (f = e.length; h < f; h++) if (i = e[h], i.nodeType == 1)(b = i.className) && (" " + b + " ").indexOf(a) > -1 && g.push(i)
            }
            return g
        }
        function h(a, b, d, e) {
            for (var g = [], d = e.getElementsByTagName(d), h = 0, f = d.length; h < f; h++) e = d[h],
            e.nodeType == 1 && (b === null ? ta(e, a) !== null && g.push(e) : b === c(ta(e, a)) && g.push(e));
            return g
        }
        function f(a, b) {
            var c = [],
            i,
            k = (i = /^((?:\\.|[^.#\s\[<>])+)/.exec(a)) ? i[1] : "*";
            if (i = /#((?:[\w\-]|\\.)+)$/.exec(a)) c = e(i[1], k, b);
            else if (i = /\.((?:[\w\-]|\\.)+)$/.exec(a)) c = g(i[1], k, b);
            else if (i = /\[((?:[\w\-]|\\.)+)\]/.exec(a)) c = h(i[1].toLowerCase(), null, k, b);
            else if (i = /\[((?:[\w\-]|\\.)+)\s*=\s*['"]?((?:\\.|[^'"]+)+)['"]?\]/.exec(a)) {
                c = i[1].toLowerCase();
                i = i[2];
                if (c === "id") k = e(i, k, b);
                else if (c === "class") k = g(i, k, b);
                else if (c === "name") {
                    c = [];
                    i = (b.ownerDocument || b).getElementsByName(i.replace(/\\/g, ""));
                    for (var n, q = 0,
                    s = i.length; q < s; q++) n = i[q],
                    d(k, n.nodeName) && sa(b, n) && n.getAttributeNode("name") && c.push(n);
                    k = c
                } else k = h(c, i, k, b);
                c = k
            } else {
                k = b.getElementsByTagName(k);
                n = 0;
                for (q = k.length; n < q; n++) i = k[n],
                i.nodeType == 1 && c.push(i)
            }
            return c
        }
        var k = a.split(",");
        if (k.length > 1) {
            var n = [];
            m(k,
            function() {
                m(ua(this, b),
                function() {
                    L(this, n) < 0 && n.push(this)
                })
            });
            return n
        }
        for (var b = b || document,
        k = [], s, q = /((?:\\.|[^\s>])+|[\s>])/g; s = q.exec(a);) s[1] !== " " && k.push(s[1]);
        s = [];
        if (k.length == 1) return f(k[0], b);
        var q = !1,
        j, D, l, o, p, w, ra, H, r, t;
        w = 0;
        for (lenth = k.length; w < lenth; w++) if (j = k[w], j === ">") q = !0;
        else {
            if (w > 0) {
                D = [];
                ra = 0;
                for (r = s.length; ra < r; ra++) {
                    o = s[ra];
                    l = f(j, o);
                    H = 0;
                    for (t = l.length; H < t; H++) p = l[H],
                    q ? o === p.parentNode && D.push(p) : D.push(p)
                }
                s = D
            } else s = f(j, b);
            if (s.length === 0) return []
        }
        return s
    }
    function Y(a) {
        if (!a) return document;
        return a.ownerDocument || a.document || a
    }
    function R(a) {
        if (!a) return z;
        a = Y(a);
        return a.parentWindow || a.defaultView
    }
    function Vb(a, b) {
        if (a.nodeType == 1) {
            var c = Y(a);
            try {
                a.innerHTML = '<img id="__kindeditor_temp_tag__" width="0" height="0" style="display:none;" />' + b;
                var d = c.getElementById("__kindeditor_temp_tag__");
                d.parentNode.removeChild(d)
            } catch(e) {
                f(a).empty(),
                f("@" + b, c).each(function() {
                    a.appendChild(this)
                })
            }
        }
    }
    function Ja(a, b, c) {
        o && B < 8 && b.toLowerCase() == "class" && (b = "className");
        a.setAttribute(b, "" + c)
    }
    function Ka(a) {
        if (!a || !a.nodeName) return "";
        return a.nodeName.toLowerCase()
    }
    function Wb(a, b) {
        var c = R(a),
        d = ca(b),
        e = "";
        c.getComputedStyle ? (c = c.getComputedStyle(a, null), e = c[d] || c.getPropertyValue(b) || a.style[d]) : a.currentStyle && (e = a.currentStyle[d] || a.style[d]);
        return e
    }
    function I(a) {
        a = a || document;
        return S ? a.body: a.documentElement
    }
    function Z(a) {
        var a = a || document,
        b;
        o || La ? (b = I(a).scrollLeft, a = I(a).scrollTop) : (b = R(a).scrollX, a = R(a).scrollY);
        return {
            x: b,
            y: a
        }
    }
    function E(a) {
        this.init(a)
    }
    function pb(a) {
        a.collapsed = a.startContainer === a.endContainer && a.startOffset === a.endOffset;
        return a
    }
    function Ma(a, b, c) {
        function d(d, e, g) {
            var h = d.nodeValue.length,
            k;
            b && (k = d.cloneNode(!0), k = e > 0 ? k.splitText(e) : k, g < h && k.splitText(g - e));
            if (c) {
                var n = d;
                e > 0 && (n = d.splitText(e), a.setStart(d, e));
                g < h && (d = n.splitText(g - e), a.setEnd(d, 0));
                f.push(n)
            }
            return k
        }
        function e() {
            c && a.up().collapse(!0);
            for (var b = 0,
            d = f.length; b < d; b++) {
                var e = f[b];
                e.parentNode && e.parentNode.removeChild(e)
            }
        }
        function g(e, j) {
            for (var l = e.firstChild,
            o; l;) {
                o = (new M(h)).selectNode(l);
                n = o.compareBoundaryPoints(fa, a);
                n >= 0 && s <= 0 && (s = o.compareBoundaryPoints(ga, a));
                s >= 0 && q <= 0 && (q = o.compareBoundaryPoints($, a));
                q >= 0 && m <= 0 && (m = o.compareBoundaryPoints(ha, a));
                if (m >= 0) return ! 1;
                o = l.nextSibling;
                if (n > 0) if (l.nodeType == 1) if (s >= 0 && q <= 0) b && j.appendChild(l.cloneNode(!0)),
                c && f.push(l);
                else {
                    var D;
                    b && (D = l.cloneNode(!1), j.appendChild(D));
                    if (g(l, D) === !1) return ! 1
                } else if (l.nodeType == 3 && (l = l == k.startContainer ? d(l, k.startOffset, l.nodeValue.length) : l == k.endContainer ? d(l, 0, k.endOffset) : d(l, 0, l.nodeValue.length), b)) try {
                    j.appendChild(l)
                } catch(G) {}
                l = o
            }
        }
        var h = a.doc,
        f = [],
        k = a.cloneRange().down(),
        n = -1,
        s = -1,
        q = -1,
        m = -1,
        j = a.commonAncestor(),
        l = h.createDocumentFragment();
        if (j.nodeType == 3) return j = d(j, a.startOffset, a.endOffset),
        b && l.appendChild(j),
        e(),
        b ? l: a;
        g(j, l);
        c && a.up().collapse(!0);
        for (var j = 0,
        o = f.length; j < o; j++) {
            var p = f[j];
            p.parentNode && p.parentNode.removeChild(p)
        }
        return b ? l: a
    }
    function ia(a, b) {
        for (var c = b; c;) {
            var d = f(c);
            if (d.name == "marquee" || d.name == "select") return;
            c = c.parentNode
        }
        try {
            a.moveToElementText(b)
        } catch(e) {}
    }
    function qb(a, b) {
        var c = a.parentElement().ownerDocument,
        d = a.duplicate();
        d.collapse(b);
        var e = d.parentElement(),
        g = e.childNodes;
        if (g.length === 0) return {
            node: e.parentNode,
            offset: f(e).index()
        };
        var h = c,
        i = 0,
        k = -1,
        n = a.duplicate();
        ia(n, e);
        for (var j = 0,
        q = g.length; j < q; j++) {
            var l = g[j],
            k = n.compareEndPoints("StartToStart", d);
            if (k === 0) return {
                node: l.parentNode,
                offset: j
            };
            if (l.nodeType == 1) {
                var m = a.duplicate(),
                o,
                p = f(l),
                r = l;
                p.isControl() && (o = c.createElement("span"), p.after(o), r = o, i += p.text().replace(/\r\n|\n|\r/g, "").length);
                ia(m, r);
                n.setEndPoint("StartToEnd", m);
                k > 0 ? i += m.text.replace(/\r\n|\n|\r/g, "").length: i = 0;
                o && f(o).remove()
            } else l.nodeType == 3 && (n.moveStart("character", l.nodeValue.length), i += l.nodeValue.length);
            k < 0 && (h = l)
        }
        if (k < 0 && h.nodeType == 1) return {
            node: e,
            offset: f(e.lastChild).index() + 1
        };
        if (k > 0) for (; h.nextSibling && h.nodeType == 1;) h = h.nextSibling;
        n = a.duplicate();
        ia(n, e);
        n.setEndPoint("StartToEnd", d);
        i -= n.text.replace(/\r\n|\n|\r/g, "").length;
        if (k > 0 && h.nodeType == 3) for (c = h.previousSibling; c && c.nodeType == 3;) i -= c.nodeValue.length,
        c = c.previousSibling;
        return {
            node: h,
            offset: i
        }
    }
    function rb(a, b) {
        var c = a.ownerDocument || a,
        d = c.body.createTextRange();
        if (c == a) return d.collapse(!0),
        d;
        if (a.nodeType == 1 && a.childNodes.length > 0) {
            var e = a.childNodes,
            g;
            b === 0 ? (g = e[0], e = !0) : (g = e[b - 1], e = !1);
            if (!g) return d;
            if (f(g).name === "head") return b === 1 && (e = !0),
            b === 2 && (e = !1),
            d.collapse(e),
            d;
            if (g.nodeType == 1) {
                var h = f(g),
                i;
                h.isControl() && (i = c.createElement("span"), e ? h.before(i) : h.after(i), g = i);
                ia(d, g);
                d.collapse(e);
                i && f(i).remove();
                return d
            }
            a = g;
            b = e ? 0 : g.nodeValue.length
        }
        c = c.createElement("span");
        f(a).before(c);
        ia(d, c);
        d.moveStart("character", b);
        f(c).remove();
        return d
    }
    function sb(a) {
        function b(a) {
            if (f(a.node).name == "tr") a.node = a.node.cells[a.offset],
            a.offset = 0
        }
        var c;
        if (o) {
            if (a.item) return c = Y(a.item(0)),
            c = new M(c),
            c.selectNode(a.item(0)),
            c;
            c = a.parentElement().ownerDocument;
            var d = qb(a, !0),
            a = qb(a, !1);
            b(d);
            b(a);
            c = new M(c);
            c.setStart(d.node, d.offset);
            c.setEnd(a.node, a.offset);
            return c
        }
        d = a.startContainer;
        c = d.ownerDocument || d;
        c = new M(c);
        c.setStart(d, a.startOffset);
        c.setEnd(a.endContainer, a.endOffset);
        return c
    }
    function M(a) {
        this.init(a)
    }
    function Na(a) {
        if (!a.nodeName) return a.constructor === M ? a: sb(a);
        return new M(a)
    }
    function N(a, b, c) {
        try {
            a.execCommand(b, !1, c)
        } catch(d) {}
    }
    function tb(a, b) {
        var c = "";
        try {
            c = a.queryCommandValue(b)
        } catch(d) {}
        typeof c !== "string" && (c = "");
        return c
    }
    function Oa(a) {
        var b = R(a);
        return a.selection || b.getSelection()
    }
    function ub(a) {
        var b = {},
        c, d;
        m(a,
        function(a, g) {
            c = a.split(",");
            for (var h = 0,
            f = c.length; h < f; h++) d = c[h],
            b[d] = g
        });
        return b
    }
    function Pa(a, b) {
        return vb(a, b, "*") || vb(a, b)
    }
    function vb(a, b, c) {
        c = c || a.name;
        if (a.type !== 1) return ! 1;
        b = ub(b);
        if (!b[c]) return ! 1;
        for (var c = b[c].split(","), b = 0, d = c.length; b < d; b++) {
            var e = c[b];
            if (e === "*") return ! 0;
            var g = /^(\.?)([^=]+)(?:=([^=]*))?$/.exec(e),
            h = g[1] ? "css": "attr",
            e = g[2],
            g = g[3] || "";
            if (g === "" && a[h](e) !== "") return ! 0;
            if (g !== "" && a[h](e) === g) return ! 0
        }
        return ! 1
    }
    function Qa(a, b) {
        a.type == 1 && (wb(a, b, "*"), wb(a, b))
    }
    function wb(a, b, c) {
        c = c || a.name;
        if (a.type === 1 && (b = ub(b), b[c])) {
            for (var c = b[c].split(","), b = !1, d = 0, e = c.length; d < e; d++) {
                var g = c[d];
                if (g === "*") {
                    b = !0;
                    break
                }
                var h = /^(\.?)([^=]+)(?:=([^=]*))?$/.exec(g),
                g = h[2];
                h[1] ? (g = ca(g), a[0].style[g] && (a[0].style[g] = "")) : a.removeAttr(g)
            }
            b && a.remove(!0)
        }
    }
    function Ra(a) {
        for (; a.first();) a = a.first();
        return a
    }
    function aa(a) {
        return a.type == 1 && a.html().replace(/<[^>]+>/g, "") === ""
    }
    function Xb(a, b, c) {
        m(b,
        function(b, c) {
            b !== "style" && a.attr(b, c)
        });
        m(c,
        function(b, c) {
            a.css(b, c)
        })
    }
    function xb(a) {
        for (; a && a.name != "body";) {
            if (Ha[a.name] || a.name == "div" && a.hasClass("ke-script")) return ! 0;
            a = a.parent()
        }
        return ! 1
    }
    function va(a) {
        this.init(a)
    }
    function yb(a) {
        a.nodeName && (a = Y(a), a = Na(a).selectNodeContents(a.body).collapse(!1));
        return new va(a)
    }
    function Sa(a) {
        var b = a.moveEl,
        c = a.moveFn,
        d = a.clickEl || b,
        e = a.beforeDrag,
        g = [document],
        h = [{
            x: 0,
            y: 0
        }],
        i = []; (a.iframeFix === j || a.iframeFix) && f("iframe").each(function() {
            var a;
            try {
                a = Ta(this),
                f(a)
            } catch(b) {
                a = null
            }
            a && (g.push(a), h.push(f(this).pos()))
        });
        d.mousedown(function(a) {
            var n = d.get(),
            j = t(b.css("left")),
            q = t(b.css("top")),
            l = b.width(),
            o = b.height(),
            p = a.pageX,
            r = a.pageY,
            u = !0;
            e && e();
            m(g,
            function(a, b) {
                function e(b) {
                    if (u) {
                        var g = O(h[a].x + b.pageX - p),
                        f = O(h[a].y + b.pageY - r);
                        c.call(d, j, q, l, o, g, f)
                    }
                    b.stop()
                }
                function g(a) {
                    a.stop()
                }
                function k(a) {
                    u = !1;
                    n.releaseCapture && n.releaseCapture();
                    m(i,
                    function() {
                        f(this.doc).unbind("mousemove", this.move).unbind("mouseup", this.up).unbind("selectstart", this.select)
                    });
                    a.stop()
                }
                f(b).mousemove(e).mouseup(k).bind("selectstart", g);
                i.push({
                    doc: b,
                    move: e,
                    up: k,
                    select: g
                })
            });
            n.setCapture && n.setCapture()
        })
    }
    function P(a) {
        this.init(a)
    }
    function Ua(a) {
        return new P(a)
    }
    function Ta(a) {
        a = f(a)[0];
        return a.contentDocument || a.contentWindow.document
    }
    function Yb(a, b, c, d) {
        var e = [Va === "" ? "<html>": '<html dir="' + Va + '">', '<head><meta charset="utf-8" /><title>KindEditor</title>', "<style>", "html {margin:0;padding:0;}", "body {margin:0;padding:5px;}", 'body, td {font:12px/1.5 "sans serif",tahoma,verdana,helvetica;}', "body, p, div {word-wrap: break-word;}", "p {margin:5px 0;}", "table {border-collapse:collapse;}", "img {border:0;}", "noscript {display:none;}", "table.ke-zeroborder td {border:1px dotted #AAA;}", "img.ke-flash {", "\tborder:1px solid #AAA;", "\tbackground-image:url(" + a + "common/flash.gif);", "\tbackground-position:center center;", "\tbackground-repeat:no-repeat;", "\twidth:100px;", "\theight:100px;", "}", "img.ke-rm {", "\tborder:1px solid #AAA;", "\tbackground-image:url(" + a + "common/rm.gif);", "\tbackground-position:center center;", "\tbackground-repeat:no-repeat;", "\twidth:100px;", "\theight:100px;", "}", "img.ke-media {", "\tborder:1px solid #AAA;", "\tbackground-image:url(" + a + "common/media.gif);", "\tbackground-position:center center;", "\tbackground-repeat:no-repeat;", "\twidth:100px;", "\theight:100px;", "}", "img.ke-anchor {", "\tborder:1px dashed #666;", "\twidth:16px;", "\theight:16px;", "}", ".ke-script, .ke-noscript {", "\tdisplay:none;", "\tfont-size:0;", "\twidth:0;", "\theight:0;", "}", ".ke-pagebreak {", "\tborder:1px dotted #AAA;", "\tfont-size:0;", "\theight:2px;", "}", "</style>"];
        V(c) || (c = [c]);
        m(c,
        function(a, b) {
            b && e.push('<link href="' + b + '" rel="stylesheet" />')
        });
        d && e.push("<style>" + d + "</style>");
        e.push("</head><body " + (b ? 'class="' + b + '"': "") + "></body></html>");
        return e.join("\n")
    }
    function ja(a, b) {
        return a.hasVal() ? a.val(b) : a.html(b)
    }
    function wa(a) {
        this.init(a)
    }
    function zb(a) {
        return new wa(a)
    }
    function Ab(a, b) {
        var c = this.get(a);
        c && !c.hasClass("ke-disabled") && b(c)
    }
    function Wa(a) {
        this.init(a)
    }
    function Bb(a) {
        return new Wa(a)
    }
    function xa(a) {
        this.init(a)
    }
    function Xa(a) {
        return new xa(a)
    }
    function ya(a) {
        this.init(a)
    }
    function Cb(a) {
        return new ya(a)
    }
    function Db(a) {
        this.init(a)
    }
    function za(a) {
        this.init(a)
    }
    function Eb(a) {
        return new za(a)
    }
    function Ya(a, b) {
        var c = document.getElementsByTagName("head")[0] || (S ? document.body: document.documentElement),
        d = document.createElement("script");
        c.appendChild(d);
        d.src = a;
        d.charset = "utf-8";
        d.onload = d.onreadystatechange = function() {
            if (!this.readyState || this.readyState === "loaded") b && b(),
            d.onload = d.onreadystatechange = null,
            c.removeChild(d)
        }
    }
    function Fb(a) {
        var b = a.indexOf("?");
        return b > 0 ? a.substr(0, b) : a
    }
    function Za(a) {
        for (var b = document.getElementsByTagName("head")[0] || (S ? document.body: document.documentElement), c = document.createElement("link"), d = Fb(pa(a, "absolute")), e = f('link[rel="stylesheet"]', b), g = 0, h = e.length; g < h; g++) if (Fb(pa(e[g].href, "absolute")) === d) return;
        b.appendChild(c);
        c.href = a;
        c.rel = "stylesheet"
    }
    function Gb(a, b) {
        if (a === j) return T;
        if (!b) return T[a];
        T[a] = b
    }
    function Hb(a) {
        var b, c = "core";
        if (b = /^(\w+)\.(\w+)$/.exec(a)) c = b[1],
        a = b[2];
        return {
            ns: c,
            key: a
        }
    }
    function Ib(a, b) {
        b = b === j ? f.options.langType: b;
        if (typeof a === "string") {
            if (!K[b]) return "no language";
            var c = a.length - 1;
            if (a.substr(c) === ".") return K[b][a.substr(0, c)];
            c = Hb(a);
            return K[b][c.ns][c.key]
        }
        m(a,
        function(a, c) {
            var g = Hb(a);
            K[b] || (K[b] = {});
            K[b][g.ns] || (K[b][g.ns] = {});
            K[b][g.ns][g.key] = c
        })
    }
    function Aa(a, b) {
        if (!a.collapsed) {
            var a = a.cloneRange().up(),
            c = a.startContainer,
            d = a.startOffset;
            if (ba || a.isControl()) if ((c = f(c.childNodes[d])) && c.name == "img" && b(c)) return c
        }
    }
    function Zb() {
        var a = this;
        f(a.edit.doc).contextmenu(function(b) {
            a.menu && a.hideMenu();
            if (a.useContextmenu) {
                if (a._contextmenus.length !== 0) {
                    var c = 0,
                    d = [];
                    for (m(a._contextmenus,
                    function() {
                        if (this.title == "-") d.push(this);
                        else if (this.cond && this.cond() && (d.push(this), this.width && this.width > c)) c = this.width
                    }); d.length > 0 && d[0].title == "-";) d.shift();
                    for (; d.length > 0 && d[d.length - 1].title == "-";) d.pop();
                    var e = null;
                    m(d,
                    function(a) {
                        this.title == "-" && e.title == "-" && delete d[a];
                        e = this
                    });
                    if (d.length > 0) {
                        b.preventDefault();
                        var g = f(a.edit.iframe).pos(),
                        h = Xa({
                            x: g.x + b.clientX,
                            y: g.y + b.clientY,
                            width: c,
                            css: {
                                visibility: "hidden"
                            },
                            shadowMode: a.shadowMode
                        });
                        m(d,
                        function() {
                            this.title && h.addItem(this)
                        });
                        var g = I(h.doc),
                        i = h.div.height();
                        b.clientY + i >= g.clientHeight - 100 && h.pos(h.x, t(h.y) - i);
                        h.div.css("visibility", "visible");
                        a.menu = h
                    }
                }
            } else b.preventDefault()
        })
    }
    function $b() {
        function a(a) {
            for (a = f(a.commonAncestor()); a;) {
                if (a.type == 1 && !a.isStyle()) break;
                a = a.parent()
            }
            return a.name
        }
        var b = this,
        c = b.edit.doc,
        d = b.newlineTag;
        if (! (o && d !== "br") && (!ka || !(B < 3 && d !== "p")) && !(La && B < 9)) {
            var e = u("h1,h2,h3,h4,h5,h6,pre,li"),
            g = u("p,h1,h2,h3,h4,h5,h6,pre,li,blockquote");
            f(c).keydown(function(f) {
                if (! (f.which != 13 || f.shiftKey || f.ctrlKey || f.altKey)) {
                    b.cmd.selection();
                    var i = a(b.cmd.range);
                    i == "marquee" || i == "select" || (d === "br" && !e[i] ? (f.preventDefault(), b.insertHtml("<br />" + (o && B < 9 ? "": "\u200b"))) : g[i] || N(c, "formatblock", "<p>"))
                }
            });
            f(c).keyup(function(e) {
                if (! (e.which != 13 || e.shiftKey || e.ctrlKey || e.altKey) && d != "br") if (b.cmd.selection(), e = a(b.cmd.range), !(e == "marquee" || e == "select")) if (g[e] || N(c, "formatblock", "<p>"), e = b.cmd.commonAncestor("div")) {
                    for (var i = f("<p></p>"), k = e[0].firstChild; k;) {
                        var n = k.nextSibling;
                        i.append(k);
                        k = n
                    }
                    e.before(i);
                    e.remove();
                    b.cmd.range.selectNodeContents(i[0]);
                    b.cmd.select()
                }
            })
        }
    }
    function ac() {
        var a = this,
        b = a.edit.doc;
        f(b).keydown(function(c) {
            if (c.which == 9) if (c.preventDefault(), a.afterTab) a.afterTab.call(a, c);
            else {
                var c = a.cmd,
                d = c.range;
                d.shrink();
                d.collapsed && d.startContainer.nodeType == 1 && (d.insertNode(f("@&nbsp;", b)[0]), c.select());
                a.insertHtml("&nbsp;&nbsp;&nbsp;&nbsp;")
            }
        })
    }
    function bc() {
        var a = this;
        f(a.edit.textarea[0], a.edit.win).focus(function(b) {
            a.afterFocus && a.afterFocus.call(a, b)
        }).blur(function(b) {
            a.afterBlur && a.afterBlur.call(a, b)
        })
    }
    function U(a) {
        return A(a.replace(/<span [^>]*id="?__kindeditor_bookmark_\w+_\d+__"?[^>]*><\/span>/ig, ""))
    }
    function $a(a) {
        return a.replace(/<div[^>]+class="?__kindeditor_paste__"?[^>]*>[\s\S]*?<\/div>/ig, "")
    }
    function Jb(a, b) {
        if (a.length === 0) a.push(b);
        else {
            var c = a[a.length - 1];
            U(b.html) !== U(c.html) && a.push(b)
        }
    }
    function Kb(a, b) {
        var c = this.edit,
        d = c.doc.body,
        e, g;
        if (a.length === 0) return this;
        c.designMode ? (e = this.cmd.range, g = e.createBookmark(!0), g.html = d.innerHTML) : g = {
            html: d.innerHTML
        };
        Jb(b, g);
        var h = a.pop();
        U(g.html) === U(h.html) && a.length > 0 && (h = a.pop());
        c.designMode ? (c.html(h.html), h.start && (e.moveToBookmark(h), this.select())) : f(d).html(U(h.html));
        return this
    }
    function la(a) {
        function b(a, b) {
            la.prototype[a] === j && (c[a] = b);
            c.options[a] = b
        }
        var c = this;
        c.options = {};
        m(a,
        function(c) {
            b(c, a[c])
        });
        m(f.options,
        function(a, d) {
            c[a] === j && b(a, d)
        });
        var d = f(c.srcElement || "<textarea/>");
        if (!c.width) c.width = d[0].style.width || d.width();
        if (!c.height) c.height = d[0].style.height || d.height();
        b("width", l(c.width, c.minWidth));
        b("height", l(c.height, c.minHeight));
        b("width", r(c.width));
        b("height", r(c.height));
        if (cc && (!dc || B < 534)) c.designMode = !1;
        c.srcElement = d;
        c.initContent = "";
        c.plugin = {};
        c.isCreated = !1;
        c.isLoading = !1;
        c._handlers = {};
        c._contextmenus = [];
        c._undoStack = [];
        c._redoStack = [];
        c._calledPlugins = {};
        c._firstAddBookmark = !0;
        c.menu = c.contextmenu = null;
        c.dialogs = []
    }
    function Lb(a, b) {
        function c(a) {
            m(T,
            function(b, c) {
                c.call(a, KindEditor)
            });
            return a.create()
        }
        b = b || {};
        b.basePath = l(b.basePath, f.basePath);
        b.themesPath = l(b.themesPath, b.basePath + "themes/");
        b.langPath = l(b.langPath, b.basePath + "lang/");
        b.pluginsPath = l(b.pluginsPath, b.basePath + "plugins/");
        if (l(b.loadStyleMode, f.options.loadStyleMode)) {
            var d = l(b.themeType, f.options.themeType);
            Za(b.themesPath + "default/default.css");
            Za(b.themesPath + d + "/" + d + ".css")
        }
        if (d = f(a)) {
            if (d.length > 1) return d.each(function() {
                Lb(this, b)
            }),
            _instances[0];
            b.srcElement = d[0];
            var e = new la(b);
            _instances.push(e);
            if (K[e.langType]) return c(e);
            Ya(e.langPath + e.langType + ".js?ver=" + encodeURIComponent(f.DEBUG ? Ba: Ca),
            function() {
                c(e)
            });
            return e
        }
    }
    if (!z.KindEditor) {
        if (!z.console) z.console = {};
        if (!console.log) console.log = function() {};
        var Ca = "4.1 (2012-05-12)",
        p = navigator.userAgent.toLowerCase(),
        o = p.indexOf("msie") > -1 && p.indexOf("opera") == -1,
        ka = p.indexOf("gecko") > -1 && p.indexOf("khtml") == -1,
        ba = p.indexOf("applewebkit") > -1,
        La = p.indexOf("opera") > -1,
        cc = p.indexOf("mobile") > -1,
        dc = /ipad|iphone|ipod/.test(p),
        S = document.compatMode != "CSS1Compat",
        B = (p = /(?:msie|firefox|webkit|opera)[\/:\s](\d+)/.exec(p)) ? p[1] : "0",
        Ba = (new Date).getTime(),
        O = Math.round,
        f = {
            DEBUG: !1,
            VERSION: Ca,
            IE: o,
            GECKO: ka,
            WEBKIT: ba,
            OPERA: La,
            V: B,
            TIME: Ba,
            each: m,
            isArray: V,
            isFunction: bb,
            inArray: L,
            inString: ma,
            trim: A,
            addUnit: r,
            removeUnit: t,
            escape: C,
            unescape: Ea,
            toCamel: ca,
            toHex: na,
            toMap: u,
            toArray: Fa,
            undef: l,
            invalidUrl: function(a) {
                return ! a || /[<>"]/.test(a)
            },
            addParam: function(a, b) {
                return a.indexOf("?") >= 0 ? a + "&" + b: a + "?" + b
            },
            extend: F,
            json: cb
        },
        jb = u("a,abbr,acronym,b,basefont,bdo,big,br,button,cite,code,del,dfn,em,font,i,img,input,ins,kbd,label,map,q,s,samp,select,small,span,strike,strong,sub,sup,textarea,tt,u,var"),
        kb = u("address,applet,blockquote,body,center,dd,dir,div,dl,dt,fieldset,form,frameset,h1,h2,h3,h4,h5,h6,head,hr,html,iframe,ins,isindex,li,map,menu,meta,noframes,noscript,object,ol,p,pre,script,style,table,tbody,td,tfoot,th,thead,title,tr,ul"),
        ib = u("area,base,basefont,br,col,frame,hr,img,input,isindex,link,meta,param,embed"),
        Mb = u("b,basefont,big,del,em,font,i,s,small,span,strike,strong,sub,sup,u"),
        ec = u("img,table,input,textarea,button"),
        Ha = u("pre,style,script"),
        Da = u("html,head,body,td,tr,table,ol,ul,li");
        u("colgroup,dd,dt,li,options,p,td,tfoot,th,thead,tr");
        var Tb = u("checked,compact,declare,defer,disabled,ismap,multiple,nohref,noresize,noshade,nowrap,readonly,selected"),
        Nb = u("input,button,textarea,select");
        f.basePath = function() {
            for (var a = document.getElementsByTagName("script"), b, c = 0, d = a.length; c < d; c++) if (b = a[c].src || "", /kindeditor[\w\-\.]*\.js/.test(b)) return b.substring(0, b.lastIndexOf("/") + 1);
            return ""
        } ();
        f.options = {
            designMode: !0,
            fullscreenMode: !1,
            filterMode: !1,
            wellFormatMode: !0,
            shadowMode: !0,
            loadStyleMode: !0,
            basePath: f.basePath,
            themesPath: f.basePath + "themes/",
            langPath: f.basePath + "lang/",
            pluginsPath: f.basePath + "plugins/",
            themeType: "default",
            langType: "zh_CN",
            urlType: "",
            newlineTag: "p",
            resizeType: 2,
            syncType: "form",
            pasteType: 2,
            dialogAlignType: "page",
            useContextmenu: !0,
            fullscreenShortcut: !0,
            bodyClass: "ke-content",
            indentChar: "\t",
            cssPath: "",
            cssData: "",
            minWidth: 650,
            minHeight: 100,
            minChangeSize: 5,
            items: ["source", "|", "undo", "redo", "|", "preview", "print", "template", "code", "cut", "copy", "paste", "plainpaste", "wordpaste", "|", "justifyleft", "justifycenter", "justifyright", "justifyfull", "insertorderedlist", "insertunorderedlist", "indent", "outdent", "subscript", "superscript", "clearhtml", "quickformat", "selectall", "|", "fullscreen", "/", "formatblock", "fontname", "fontsize", "|", "forecolor", "hilitecolor", "bold", "italic", "underline", "strikethrough", "lineheight", "removeformat", "|", "image", "multiimage", "flash", "media", "insertfile", "table", "hr", "emoticons", "baidumap", "pagebreak", "anchor", "link", "unlink", "|", "about"],
            noDisableItems: ["source", "fullscreen"],
            colorTable: [["#E53333", "#E56600", "#FF9900", "#64451D", "#DFC5A4", "#FFE500"], ["#009900", "#006600", "#99BB00", "#B8D100", "#60D978", "#00D5FF"], ["#337FE5", "#003399", "#4C33E5", "#9933E5", "#CC33E5", "#EE33EE"], ["#FFFFFF", "#CCCCCC", "#999999", "#666666", "#333333", "#000000"]],
            fontSizeTable: ["9px", "10px", "12px", "14px", "16px", "18px", "24px", "32px"],
            htmlTags: {
                font: ["color", "size", "face", ".background-color"],
                span: [".color", ".background-color", ".font-size", ".font-family", ".background", ".font-weight", ".font-style", ".text-decoration", ".vertical-align", ".line-height"],
                div: ["align", ".border", ".margin", ".padding", ".text-align", ".color", ".background-color", ".font-size", ".font-family", ".font-weight", ".background", ".font-style", ".text-decoration", ".vertical-align", ".margin-left"],
                table: ["border", "cellspacing", "cellpadding", "width", "height", "align", "bordercolor", ".padding", ".margin", ".border", "bgcolor", ".text-align", ".color", ".background-color", ".font-size", ".font-family", ".font-weight", ".font-style", ".text-decoration", ".background", ".width", ".height", ".border-collapse"],
                "td,th": ["align", "valign", "width", "height", "colspan", "rowspan", "bgcolor", ".text-align", ".color", ".background-color", ".font-size", ".font-family", ".font-weight", ".font-style", ".text-decoration", ".vertical-align", ".background", ".border"],
                a: ["href", "target", "name"],
                embed: ["src", "width", "height", "type", "loop", "autostart", "quality", ".width", ".height", "align", "allowscriptaccess"],
                img: ["src", "width", "height", "border", "alt", "title", "align", ".width", ".height", ".border"],
                "p,ol,ul,li,blockquote,h1,h2,h3,h4,h5,h6": ["align", ".text-align", ".color", ".background-color", ".font-size", ".font-family", ".background", ".font-weight", ".font-style", ".text-decoration", ".vertical-align", ".text-indent", ".margin-left"],
                pre: ["class"],
                hr: ["class", ".page-break-after"],
                "br,tbody,tr,strong,b,sub,sup,em,i,u,strike,s,del": []
            },
            layout: '<div class="container"><div class="toolbar"></div><div class="edit"></div><div class="statusbar"></div></div>'
        };
        var db = !1,
        Ob = u("8,9,13,32,46,48..57,59,61,65..90,106,109..111,188,190..192,219..222"),
        p = u("33..40"),
        ab = {};
        m(Ob,
        function(a, b) {
            ab[a] = b
        });
        m(p,
        function(a, b) {
            ab[a] = b
        });
        var fc = "altKey,attrChange,attrName,bubbles,button,cancelable,charCode,clientX,clientY,ctrlKey,currentTarget,data,detail,eventPhase,fromElement,handler,keyCode,metaKey,newValue,offsetX,offsetY,originalTarget,pageX,pageY,prevValue,relatedNode,relatedTarget,screenX,screenY,shiftKey,srcElement,target,toElement,view,wheelDelta,which".split(",");
        F(eb, {
            init: function(a, b) {
                var c = this,
                d = a.ownerDocument || a.document || a;
                c.event = b;
                m(fc,
                function(a, d) {
                    c[d] = b[d]
                });
                if (!c.target) c.target = c.srcElement || d;
                if (c.target.nodeType === 3) c.target = c.target.parentNode;
                if (!c.relatedTarget && c.fromElement) c.relatedTarget = c.fromElement === c.target ? c.toElement: c.fromElement;
                if (c.pageX == null && c.clientX != null) {
                    var e = d.documentElement,
                    d = d.body;
                    c.pageX = c.clientX + (e && e.scrollLeft || d && d.scrollLeft || 0) - (e && e.clientLeft || d && d.clientLeft || 0);
                    c.pageY = c.clientY + (e && e.scrollTop || d && d.scrollTop || 0) - (e && e.clientTop || d && d.clientTop || 0)
                }
                if (!c.which && (c.charCode || c.charCode === 0 ? c.charCode: c.keyCode)) c.which = c.charCode || c.keyCode;
                if (!c.metaKey && c.ctrlKey) c.metaKey = c.ctrlKey;
                if (!c.which && c.button !== j) c.which = c.button & 1 ? 1 : c.button & 2 ? 3 : c.button & 4 ? 2 : 0;
                switch (c.which) {
                case 186:
                    c.which = 59;
                    break;
                case 187:
                case 107:
                case 43:
                    c.which = 61;
                    break;
                case 189:
                case 45:
                    c.which = 109;
                    break;
                case 42:
                    c.which = 106;
                    break;
                case 47:
                    c.which = 111;
                    break;
                case 78:
                    c.which = 110
                }
                c.which >= 96 && c.which <= 105 && (c.which -= 48)
            },
            preventDefault: function() {
                var a = this.event;
                a.preventDefault && a.preventDefault();
                a.returnValue = !1
            },
            stopPropagation: function() {
                var a = this.event;
                a.stopPropagation && a.stopPropagation();
                a.cancelBubble = !0
            },
            stop: function() {
                this.preventDefault();
                this.stopPropagation()
            }
        });
        var W = "kindeditor_" + Ba,
        gb = 0,
        v = {};
        o && z.attachEvent("onunload",
        function() {
            m(v,
            function(a, b) {
                b.el && da(b.el)
            })
        });
        f.ctrl = Ga;
        f.ready = function(a) {
            function b() {
                e || (e = !0, a(KindEditor))
            }
            function c() {
                if (!e) {
                    try {
                        document.documentElement.doScroll("left")
                    } catch(a) {
                        setTimeout(c, 100);
                        return
                    }
                    b()
                }
            }
            function d() {
                document.readyState === "complete" && b()
            }
            var e = !1;
            if (document.addEventListener) X(document, "DOMContentLoaded", b);
            else if (document.attachEvent) {
                X(document, "readystatechange", d);
                var g = !1;
                try {
                    g = z.frameElement == null
                } catch(f) {}
                document.documentElement.doScroll && g && c()
            }
            X(z, "load", b)
        };
        f.formatUrl = pa;
        f.formatHtml = Q;
        f.getCssList = ea;
        f.getAttrList = J;
        f.mediaType = mb;
        f.mediaAttrs = nb;
        f.mediaEmbed = Ia;
        f.mediaImg = ob;
        f.clearMsWord = lb;
        f.tmpl = function(a, b) {
            var c = new Function("obj", "var p=[],print=function(){p.push.apply(p,arguments);};with(obj){p.push('" + a.replace(/[\r\t\n]/g, " ").split("<%").join("\t").replace(/((^|%>)[^\t]*)'/g, "$1\r").replace(/\t=(.*?)%>/g, "',$1,'").split("\t").join("');").split("%>").join("p.push('").split("\r").join("\\'") + "');}return p.join('');");
            return b ? c(b) : c
        };
        p = document.createElement("div");
        p.setAttribute("className", "t");
        var Ub = p.className !== "t";
        f.query = function(a, b) {
            var c = ua(a, b);
            return c.length > 0 ? c[0] : null
        };
        f.queryAll = ua;
        F(E, {
            init: function(a) {
                for (var a = V(a) ? a: [a], b = 0, c = 0, d = a.length; c < d; c++) a[c] && (this[c] = a[c].constructor === E ? a[c][0] : a[c], b++);
                this.length = b;
                this.doc = Y(this[0]);
                this.name = Ka(this[0]);
                this.type = this.length > 0 ? this[0].nodeType: null;
                this.win = R(this[0]);
                this._data = {}
            },
            each: function(a) {
                for (var b = 0; b < this.length; b++) if (a.call(this[b], b, this[b]) === !1) break;
                return this
            },
            bind: function(a, b) {
                this.each(function() {
                    X(this, a, b)
                });
                return this
            },
            unbind: function(a, b) {
                this.each(function() {
                    da(this, a, b)
                });
                return this
            },
            fire: function(a) {
                if (this.length < 1) return this;
                hb(this[0], a);
                return this
            },
            hasAttr: function(a) {
                if (this.length < 1) return ! 1;
                return !! ta(this[0], a)
            },
            attr: function(a, b) {
                var c = this;
                if (a === j) return J(c.outer());
                if (typeof a === "object") return m(a,
                function(a, b) {
                    c.attr(a, b)
                }),
                c;
                if (b === j) return b = c.length < 1 ? null: ta(c[0], a),
                b === null ? "": b;
                c.each(function() {
                    Ja(this, a, b)
                });
                return c
            },
            removeAttr: function(a) {
                this.each(function() {
                    var b = a;
                    o && B < 8 && b.toLowerCase() == "class" && (b = "className");
                    Ja(this, b, "");
                    this.removeAttribute(b)
                });
                return this
            },
            get: function(a) {
                if (this.length < 1) return null;
                return this[a || 0]
            },
            eq: function(a) {
                if (this.length < 1) return null;
                return this[a] ? new E(this[a]) : null
            },
            hasClass: function(a) {
                if (this.length < 1) return ! 1;
                return ma(a, this[0].className, " ")
            },
            addClass: function(a) {
                this.each(function() {
                    if (!ma(a, this.className, " ")) this.className = A(this.className + " " + a)
                });
                return this
            },
            removeClass: function(a) {
                this.each(function() {
                    if (ma(a, this.className, " ")) this.className = A(this.className.replace(RegExp("(^|\\s)" + a + "(\\s|$)"), " "))
                });
                return this
            },
            html: function(a) {
                if (a === j) {
                    if (this.length < 1 || this.type != 1) return "";
                    return Q(this[0].innerHTML)
                }
                this.each(function() {
                    Vb(this, a)
                });
                return this
            },
            text: function() {
                if (this.length < 1) return "";
                return o ? this[0].innerText: this[0].textContent
            },
            hasVal: function() {
                if (this.length < 1) return ! 1;
                return !! Nb[Ka(this[0])]
            },
            val: function(a) {
                if (a === j) {
                    if (this.length < 1) return "";
                    return this.hasVal() ? this[0].value: this.attr("value")
                } else return this.each(function() {
                    Nb[Ka(this)] ? this.value = a: Ja(this, "value", a)
                }),
                this
            },
            css: function(a, b) {
                var c = this;
                if (a === j) return ea(c.attr("style"));
                if (typeof a === "object") return m(a,
                function(a, b) {
                    c.css(a, b)
                }),
                c;
                if (b === j) {
                    if (c.length < 1) return "";
                    return c[0].style[ca(a)] || Wb(c[0], a) || ""
                }
                c.each(function() {
                    this.style[ca(a)] = b
                });
                return c
            },
            width: function(a) {
                if (a === j) {
                    if (this.length < 1) return 0;
                    return this[0].offsetWidth
                }
                return this.css("width", r(a))
            },
            height: function(a) {
                if (a === j) {
                    if (this.length < 1) return 0;
                    return this[0].offsetHeight
                }
                return this.css("height", r(a))
            },
            opacity: function(a) {
                this.each(function() {
                    this.style.opacity === j ? this.style.filter = a == 1 ? "": "alpha(opacity=" + a * 100 + ")": this.style.opacity = a == 1 ? "": a
                });
                return this
            },
            data: function(a, b) {
                if (b === j) return this._data[a];
                this._data[a] = b;
                return this
            },
            pos: function() {
                var a = this[0],
                b = 0,
                c = 0;
                if (a) if (a.getBoundingClientRect) a = a.getBoundingClientRect(),
                c = Z(this.doc),
                b = a.left + c.x,
                c = a.top + c.y;
                else for (; a;) b += a.offsetLeft,
                c += a.offsetTop,
                a = a.offsetParent;
                return {
                    x: O(b),
                    y: O(c)
                }
            },
            clone: function(a) {
                if (this.length < 1) return new E([]);
                return new E(this[0].cloneNode(a))
            },
            append: function(a) {
                this.each(function() {
                    this.appendChild && this.appendChild(f(a)[0])
                });
                return this
            },
            appendTo: function(a) {
                this.each(function() {
                    f(a)[0].appendChild(this)
                });
                return this
            },
            before: function(a) {
                this.each(function() {
                    this.parentNode.insertBefore(f(a)[0], this)
                });
                return this
            },
            after: function(a) {
                this.each(function() {
                    this.nextSibling ? this.parentNode.insertBefore(f(a)[0], this.nextSibling) : this.parentNode.appendChild(f(a)[0])
                });
                return this
            },
            replaceWith: function(a) {
                var b = [];
                this.each(function(c, d) {
                    da(d);
                    var e = f(a)[0];
                    d.parentNode.replaceChild(e, d);
                    b.push(e)
                });
                return f(b)
            },
            empty: function() {
                this.each(function(a, b) {
                    for (var c = b.firstChild; c;) {
                        if (!b.parentNode) break;
                        var d = c.nextSibling;
                        c.parentNode.removeChild(c);
                        c = d
                    }
                });
                return this
            },
            remove: function(a) {
                var b = this;
                b.each(function(c, d) {
                    if (d.parentNode) {
                        da(d);
                        if (a) for (var e = d.firstChild; e;) {
                            var g = e.nextSibling;
                            d.parentNode.insertBefore(e, d);
                            e = g
                        }
                        d.parentNode.removeChild(d);
                        delete b[c]
                    }
                });
                b.length = 0;
                b._data = {};
                return b
            },
            show: function(a) {
                return this.css("display", a === j ? "block": a)
            },
            hide: function() {
                return this.css("display", "none")
            },
            outer: function() {
                if (this.length < 1) return "";
                var a = this.doc.createElement("div");
                a.appendChild(this[0].cloneNode(!0));
                return Q(a.innerHTML)
            },
            isSingle: function() {
                return !! ib[this.name]
            },
            isInline: function() {
                return !! jb[this.name]
            },
            isBlock: function() {
                return !! kb[this.name]
            },
            isStyle: function() {
                return !! Mb[this.name]
            },
            isControl: function() {
                return !! ec[this.name]
            },
            contains: function(a) {
                if (this.length < 1) return ! 1;
                return sa(this[0], f(a)[0])
            },
            parent: function() {
                if (this.length < 1) return null;
                var a = this[0].parentNode;
                return a ? new E(a) : null
            },
            children: function() {
                if (this.length < 1) return new E([]);
                for (var a = [], b = this[0].firstChild; b;)(b.nodeType != 3 || A(b.nodeValue) !== "") && a.push(b),
                b = b.nextSibling;
                return new E(a)
            },
            first: function() {
                var a = this.children();
                return a.length > 0 ? a.eq(0) : null
            },
            last: function() {
                var a = this.children();
                return a.length > 0 ? a.eq(a.length - 1) : null
            },
            index: function() {
                if (this.length < 1) return - 1;
                for (var a = -1,
                b = this[0]; b;) a++,
                b = b.previousSibling;
                return a
            },
            prev: function() {
                if (this.length < 1) return null;
                var a = this[0].previousSibling;
                return a ? new E(a) : null
            },
            next: function() {
                if (this.length < 1) return null;
                var a = this[0].nextSibling;
                return a ? new E(a) : null
            },
            scan: function(a, b) {
                function c(d) {
                    for (d = b ? d.firstChild: d.lastChild; d;) {
                        var e = b ? d.nextSibling: d.previousSibling;
                        if (a(d) === !1) return ! 1;
                        if (c(d) === !1) return ! 1;
                        d = e
                    }
                }
                if (! (this.length < 1)) return b = b === j ? !0 : b,
                c(this[0]),
                this
            }
        });
        m("blur,focus,focusin,focusout,load,resize,scroll,unload,click,dblclick,mousedown,mouseup,mousemove,mouseover,mouseout,mouseenter,mouseleave,change,select,submit,keydown,keypress,keyup,error,contextmenu".split(","),
        function(a, b) {
            E.prototype[b] = function(a) {
                return a ? this.bind(b, a) : this.fire(b)
            }
        });
        p = f;
        f = function(a, b) {
            function c(a) {
                a[0] || (a = []);
                return new E(a)
            }
            if (! (a === j || a === null)) {
                if (typeof a === "string") {
                    b && (b = f(b)[0]);
                    var d = a.length;
                    a.charAt(0) === "@" && (a = a.substr(1));
                    if (a.length !== d || /<.+>/.test(a)) {
                        var d = (b ? b.ownerDocument || b: document).createElement("div"),
                        e = [];
                        d.innerHTML = '<img id="__kindeditor_temp_tag__" width="0" height="0" style="display:none;" />' + a;
                        for (var g = 0,
                        h = d.childNodes.length; g < h; g++) {
                            var i = d.childNodes[g];
                            i.id != "__kindeditor_temp_tag__" && e.push(i)
                        }
                        return c(e)
                    }
                    return c(ua(a, b))
                }
                if (a && a.constructor === E) return a;
                if (V(a)) return c(a);
                return c(Fa(arguments))
            }
        };
        m(p,
        function(a, b) {
            f[a] = b
        });
        z.KindEditor = f;
        var ga = 0,
        fa = 1,
        $ = 2,
        ha = 3,
        Pb = 0;
        F(M, {
            init: function(a) {
                this.startContainer = a;
                this.startOffset = 0;
                this.endContainer = a;
                this.endOffset = 0;
                this.collapsed = !0;
                this.doc = a
            },
            commonAncestor: function() {
                function a(a) {
                    for (var b = []; a;) b.push(a),
                    a = a.parentNode;
                    return b
                }
                for (var b = a(this.startContainer), c = a(this.endContainer), d = 0, e = b.length, g = c.length, f, i; ++d;) if (f = b[e - d], i = c[g - d], !f || !i || f !== i) break;
                return b[e - d + 1]
            },
            setStart: function(a, b) {
                var c = this.doc;
                this.startContainer = a;
                this.startOffset = b;
                if (this.endContainer === c) this.endContainer = a,
                this.endOffset = b;
                return pb(this)
            },
            setEnd: function(a, b) {
                var c = this.doc;
                this.endContainer = a;
                this.endOffset = b;
                if (this.startContainer === c) this.startContainer = a,
                this.startOffset = b;
                return pb(this)
            },
            setStartBefore: function(a) {
                return this.setStart(a.parentNode || this.doc, f(a).index())
            },
            setStartAfter: function(a) {
                return this.setStart(a.parentNode || this.doc, f(a).index() + 1)
            },
            setEndBefore: function(a) {
                return this.setEnd(a.parentNode || this.doc, f(a).index())
            },
            setEndAfter: function(a) {
                return this.setEnd(a.parentNode || this.doc, f(a).index() + 1)
            },
            selectNode: function(a) {
                return this.setStartBefore(a).setEndAfter(a)
            },
            selectNodeContents: function(a) {
                var b = f(a);
                if (b.type == 3 || b.isSingle()) return this.selectNode(a);
                b = b.children();
                if (b.length > 0) return this.setStartBefore(b[0]).setEndAfter(b[b.length - 1]);
                return this.setStart(a, 0).setEnd(a, 0)
            },
            collapse: function(a) {
                if (a) return this.setEnd(this.startContainer, this.startOffset);
                return this.setStart(this.endContainer, this.endOffset)
            },
            compareBoundaryPoints: function(a, b) {
                var c = this.get(),
                d = b.get();
                if (o) {
                    var e = {};
                    e[ga] = "StartToStart";
                    e[fa] = "EndToStart";
                    e[$] = "EndToEnd";
                    e[ha] = "StartToEnd";
                    c = c.compareEndPoints(e[a], d);
                    if (c !== 0) return c;
                    var g, h, i, k;
                    if (a === ga || a === ha) g = this.startContainer,
                    i = this.startOffset;
                    if (a === fa || a === $) g = this.endContainer,
                    i = this.endOffset;
                    if (a === ga || a === fa) h = b.startContainer,
                    k = b.startOffset;
                    if (a === $ || a === ha) h = b.endContainer,
                    k = b.endOffset;
                    if (g === h) return g = i - k,
                    g > 0 ? 1 : g < 0 ? -1 : 0;
                    for (c = h; c && c.parentNode !== g;) c = c.parentNode;
                    if (c) return f(c).index() >= i ? -1 : 1;
                    for (c = g; c && c.parentNode !== h;) c = c.parentNode;
                    if (c) return f(c).index() >= k ? 1 : -1;
                    if ((c = f(h).next()) && c.contains(g)) return 1;
                    if ((c = f(g).next()) && c.contains(h)) return - 1
                } else return c.compareBoundaryPoints(a, d)
            },
            cloneRange: function() {
                return (new M(this.doc)).setStart(this.startContainer, this.startOffset).setEnd(this.endContainer, this.endOffset)
            },
            toString: function() {
                var a = this.get();
                return (o ? a.text: a.toString()).replace(/\r\n|\n|\r/g, "")
            },
            cloneContents: function() {
                return Ma(this, !0, !1)
            },
            deleteContents: function() {
                return Ma(this, !1, !0)
            },
            extractContents: function() {
                return Ma(this, !0, !0)
            },
            insertNode: function(a) {
                var b = this.startContainer,
                c = this.startOffset,
                d = this.endContainer,
                e = this.endOffset,
                g, f, i, k = 1;
                if (a.nodeName.toLowerCase() === "#document-fragment") g = a.firstChild,
                f = a.lastChild,
                k = a.childNodes.length;
                b.nodeType == 1 ? (i = b.childNodes[c]) ? (b.insertBefore(a, i), b === d && (e += k)) : b.appendChild(a) : b.nodeType == 3 && (c === 0 ? (b.parentNode.insertBefore(a, b), b.parentNode === d && (e += k)) : c >= b.nodeValue.length ? b.nextSibling ? b.parentNode.insertBefore(a, b.nextSibling) : b.parentNode.appendChild(a) : (i = c > 0 ? b.splitText(c) : b, b.parentNode.insertBefore(a, i), b === d && (d = i, e -= c)));
                g ? this.setStartBefore(g).setEndAfter(f) : this.selectNode(a);
                if (this.compareBoundaryPoints($, this.cloneRange().setEnd(d, e)) >= 1) return this;
                return this.setEnd(d, e)
            },
            surroundContents: function(a) {
                a.appendChild(this.extractContents());
                return this.insertNode(a).selectNode(a)
            },
            isControl: function() {
                var a = this.startContainer,
                b = this.startOffset,
                c = this.endContainer,
                d = this.endOffset;
                return a.nodeType == 1 && a === c && b + 1 === d && f(a.childNodes[b]).isControl()
            },
            get: function(a) {
                var b = this.doc;
                if (!o) {
                    b = b.createRange();
                    try {
                        b.setStart(this.startContainer, this.startOffset),
                        b.setEnd(this.endContainer, this.endOffset)
                    } catch(c) {}
                    return b
                }
                if (a && this.isControl()) return b = b.body.createControlRange(),
                b.addElement(this.startContainer.childNodes[this.startOffset]),
                b;
                a = this.cloneRange().down();
                b = b.body.createTextRange();
                b.setEndPoint("StartToStart", rb(a.startContainer, a.startOffset));
                b.setEndPoint("EndToStart", rb(a.endContainer, a.endOffset));
                return b
            },
            html: function() {
                return f(this.cloneContents()).outer()
            },
            down: function() {
                function a(a, d, e) {
                    if (a.nodeType == 1 && (a = f(a).children(), a.length !== 0)) {
                        var g, h, i, k;
                        d > 0 && (g = a.eq(d - 1));
                        d < a.length && (h = a.eq(d));
                        if (g && g.type == 3) i = g[0],
                        k = i.nodeValue.length;
                        h && h.type == 3 && (i = h[0], k = 0);
                        i && (e ? b.setStart(i, k) : b.setEnd(i, k))
                    }
                }
                var b = this;
                a(b.startContainer, b.startOffset, !0);
                a(b.endContainer, b.endOffset, !1);
                return b
            },
            up: function() {
                function a(a, d, e) {
                    a.nodeType == 3 && (d === 0 ? e ? b.setStartBefore(a) : b.setEndBefore(a) : d == a.nodeValue.length && (e ? b.setStartAfter(a) : b.setEndAfter(a)))
                }
                var b = this;
                a(b.startContainer, b.startOffset, !0);
                a(b.endContainer, b.endOffset, !1);
                return b
            },
            enlarge: function(a) {
                function b(b, e, g) {
                    b = f(b);
                    if (! (b.type == 3 || Da[b.name] || !a && b.isBlock())) if (e === 0) {
                        for (; ! b.prev();) {
                            e = b.parent();
                            if (!e || Da[e.name] || !a && e.isBlock()) break;
                            b = e
                        }
                        g ? c.setStartBefore(b[0]) : c.setEndBefore(b[0])
                    } else if (e == b.children().length) {
                        for (; ! b.next();) {
                            e = b.parent();
                            if (!e || Da[e.name] || !a && e.isBlock()) break;
                            b = e
                        }
                        g ? c.setStartAfter(b[0]) : c.setEndAfter(b[0])
                    }
                }
                var c = this;
                c.up();
                b(c.startContainer, c.startOffset, !0);
                b(c.endContainer, c.endOffset, !1);
                return c
            },
            shrink: function() {
                for (var a, b = this.collapsed; this.startContainer.nodeType == 1 && (a = this.startContainer.childNodes[this.startOffset]) && a.nodeType == 1 && !f(a).isSingle();) this.setStart(a, 0);
                if (b) return this.collapse(b);
                for (; this.endContainer.nodeType == 1 && this.endOffset > 0 && (a = this.endContainer.childNodes[this.endOffset - 1]) && a.nodeType == 1 && !f(a).isSingle();) this.setEnd(a, a.childNodes.length);
                return this
            },
            createBookmark: function(a) {
                var b, c = f('<span style="display:none;"></span>', this.doc)[0];
                c.id = "__kindeditor_bookmark_start_" + Pb+++"__";
                if (!this.collapsed) b = c.cloneNode(!0),
                b.id = "__kindeditor_bookmark_end_" + Pb+++"__";
                b && this.cloneRange().collapse(!1).insertNode(b).setEndBefore(b);
                this.insertNode(c).setStartAfter(c);
                return {
                    start: a ? "#" + c.id: c,
                    end: b ? a ? "#" + b.id: b: null
                }
            },
            moveToBookmark: function(a) {
                var b = this.doc,
                c = f(a.start, b),
                a = a.end ? f(a.end, b) : null;
                if (!c || c.length < 1) return this;
                this.setStartBefore(c[0]);
                c.remove();
                a && a.length > 0 ? (this.setEndBefore(a[0]), a.remove()) : this.collapse(!0);
                return this
            },
            dump: function() {
                console.log("--------------------");
                console.log(this.startContainer.nodeType == 3 ? this.startContainer.nodeValue: this.startContainer, this.startOffset);
                console.log(this.endContainer.nodeType == 3 ? this.endContainer.nodeValue: this.endContainer, this.endOffset)
            }
        });
        f.range = Na;
        f.START_TO_START = ga;
        f.START_TO_END = fa;
        f.END_TO_END = $;
        f.END_TO_START = ha;
        F(va, {
            init: function(a) {
                var b = a.doc;
                this.doc = b;
                this.win = R(b);
                this.sel = Oa(b);
                this.range = a
            },
            selection: function(a) {
                var b = this.doc,
                c;
                c = Oa(b);
                var d;
                try {
                    d = c.rangeCount > 0 ? c.getRangeAt(0) : c.createRange()
                } catch(e) {}
                c = o && (!d || !d.item && d.parentElement().ownerDocument !== b) ? null: d;
                this.sel = Oa(b);
                if (c) return this.range = Na(c),
                f(this.range.startContainer).name == "html" && this.range.selectNodeContents(b.body).collapse(!1),
                this;
                a && this.range.selectNodeContents(b.body).collapse(!1);
                return this
            },
            select: function(a) {
                var a = l(a, !0),
                b = this.sel,
                c = this.range.cloneRange().shrink(),
                d = c.startContainer,
                e = c.startOffset,
                g = Y(d),
                h = this.win,
                i,
                k = !1;
                if (a && d.nodeType == 1 && c.collapsed) {
                    if (o) {
                        b = f("<span>&nbsp;</span>", g);
                        c.insertNode(b[0]);
                        i = g.body.createTextRange();
                        try {
                            i.moveToElementText(b[0])
                        } catch(n) {}
                        i.collapse(!1);
                        i.select();
                        b.remove();
                        h.focus();
                        return this
                    }
                    if (ba && (a = d.childNodes, f(d).isInline() || e > 0 && f(a[e - 1]).isInline() || a[e] && f(a[e]).isInline())) c.insertNode(g.createTextNode("\u200b")),
                    k = !0
                }
                if (o) try {
                    i = c.get(!0),
                    i.select()
                } catch(j) {} else k && c.collapse(!1),
                i = c.get(!0),
                b.removeAllRanges(),
                b.addRange(i);
                h.focus();
                return this
            },
            wrap: function(a) {
                var b = this.range,
                c;
                c = f(a, this.doc);
                if (b.collapsed) return b.shrink(),
                b.insertNode(c[0]).selectNodeContents(c[0]),
                this;
                if (c.isBlock()) {
                    for (var d = a = c.clone(!0); d.first();) d = d.first();
                    d.append(b.extractContents());
                    b.insertNode(a[0]).selectNode(a[0]);
                    return this
                }
                b.enlarge();
                var e = b.createBookmark(),
                a = b.commonAncestor(),
                g = !1;
                f(a).scan(function(a) {
                    if (!g && a == e.start) g = !0;
                    else if (g) {
                        if (a == e.end) return ! 1;
                        var b = f(a);
                        if (!xb(b) && b.type == 3 && A(a.nodeValue).length > 0) {
                            for (var d; (d = b.parent()) && d.isStyle() && d.children().length == 1;) b = d;
                            d = c;
                            d = d.clone(!0);
                            if (b.type == 3) Ra(d).append(b.clone(!1)),
                            b.replaceWith(d);
                            else {
                                for (var a = b,
                                n; (n = b.first()) && n.children().length == 1;) b = n;
                                n = b.first();
                                for (b = b.doc.createDocumentFragment(); n;) b.appendChild(n[0]),
                                n = n.next();
                                n = a.clone(!0);
                                for (var j = Ra(n), l = n, m = !1; d;) {
                                    for (; l;) l.name === d.name && (Xb(l, d.attr(), d.css()), m = !0),
                                    l = l.first();
                                    m || j.append(d.clone(!1));
                                    m = !1;
                                    d = d.first()
                                }
                                d = n;
                                b.firstChild && Ra(d).append(b);
                                a.replaceWith(d)
                            }
                        }
                    }
                });
                b.moveToBookmark(e);
                return this
            },
            split: function(a, b) {
                for (var c = this.range,
                d = c.doc,
                e = c.cloneRange().collapse(a), g = e.startContainer, h = e.startOffset, i = g.nodeType == 3 ? g.parentNode: g, k = !1, n; i && i.parentNode;) {
                    n = f(i);
                    if (b) {
                        if (!n.isStyle()) break;
                        if (!Pa(n, b)) break
                    } else if (Da[n.name]) break;
                    k = !0;
                    i = i.parentNode
                }
                if (k) d = d.createElement("span"),
                c.cloneRange().collapse(!a).insertNode(d),
                a ? e.setStartBefore(i.firstChild).setEnd(g, h) : e.setStart(g, h).setEndAfter(i.lastChild),
                g = e.extractContents(),
                h = g.firstChild,
                k = g.lastChild,
                a ? (e.insertNode(g), c.setStartAfter(k).setEndBefore(d)) : (i.appendChild(g), c.setStartBefore(d).setEndBefore(h)),
                e = d.parentNode,
                e == c.endContainer && (i = f(d).prev(), g = f(d).next(), i && g && i.type == 3 && g.type == 3 ? c.setEnd(i[0], i[0].nodeValue.length) : a || c.setEnd(c.endContainer, c.endOffset - 1)),
                e.removeChild(d);
                return this
            },
            remove: function(a) {
                var b = this.doc,
                c = this.range;
                c.enlarge();
                if (c.startOffset === 0) {
                    for (var d = f(c.startContainer), e; (e = d.parent()) && e.isStyle() && e.children().length == 1;) d = e;
                    c.setStart(d[0], 0);
                    d = f(c.startContainer);
                    d.isBlock() && Qa(d, a); (d = d.parent()) && d.isBlock() && Qa(d, a)
                }
                if (c.collapsed) {
                    this.split(!0, a);
                    b = c.startContainer;
                    d = c.startOffset;
                    if (d > 0 && (e = f(b.childNodes[d - 1])) && aa(e)) e.remove(),
                    c.setStart(b, d - 1); (d = f(b.childNodes[d])) && aa(d) && d.remove();
                    aa(b) && (c.startBefore(b), b.remove());
                    c.collapse(!0);
                    return this
                }
                this.split(!0, a);
                this.split(!1, a);
                var g = b.createElement("span"),
                h = b.createElement("span");
                c.cloneRange().collapse(!1).insertNode(h);
                c.cloneRange().collapse(!0).insertNode(g);
                var i = [],
                k = !1;
                f(c.commonAncestor()).scan(function(a) {
                    if (!k && a == g) k = !0;
                    else {
                        if (a == h) return ! 1;
                        k && i.push(a)
                    }
                });
                f(g).remove();
                f(h).remove();
                b = c.startContainer;
                d = c.startOffset;
                e = c.endContainer;
                var n = c.endOffset;
                if (d > 0) {
                    var l = f(b.childNodes[d - 1]);
                    l && aa(l) && (l.remove(), c.setStart(b, d - 1), b == e && c.setEnd(e, n - 1));
                    if ((d = f(b.childNodes[d])) && aa(d)) d.remove(),
                    b == e && c.setEnd(e, n - 1)
                } (b = f(e.childNodes[c.endOffset])) && aa(b) && b.remove();
                b = c.createBookmark(!0);
                m(i,
                function(b, c) {
                    Qa(f(c), a)
                });
                c.moveToBookmark(b);
                return this
            },
            commonNode: function(a) {
                function b(b) {
                    for (var c = b; b;) {
                        if (Pa(f(b), a)) return f(b);
                        b = b.parentNode
                    }
                    for (; c && (c = c.lastChild);) if (Pa(f(c), a)) return f(c);
                    return null
                }
                var c = this.range,
                d = c.endContainer,
                c = c.endOffset,
                e = d.nodeType == 3 || c === 0 ? d: d.childNodes[c - 1],
                g = b(e);
                if (g) return g;
                if (e.nodeType == 1 || d.nodeType == 3 && c === 0) if (d = f(e).prev()) return b(d);
                return null
            },
            commonAncestor: function(a) {
                function b(b) {
                    for (; b;) {
                        if (b.nodeType == 1 && b.tagName.toLowerCase() === a) return b;
                        b = b.parentNode
                    }
                    return null
                }
                var c = this.range,
                d = c.startContainer,
                e = c.startOffset,
                g = c.endContainer,
                c = c.endOffset,
                g = g.nodeType == 3 || c === 0 ? g: g.childNodes[c - 1],
                d = b(d.nodeType == 3 || e === 0 ? d: d.childNodes[e - 1]),
                e = b(g);
                if (d && e && d === e) return f(d);
                return null
            },
            state: function(a) {
                var b = this.doc,
                c = !1;
                try {
                    c = b.queryCommandState(a)
                } catch(d) {}
                return c
            },
            val: function(a) {
                var b = this.doc,
                a = a.toLowerCase(),
                c = "";
                if (a === "fontfamily" || a === "fontname") return c = tb(b, "fontname"),
                c = c.replace(/['"]/g, ""),
                c.toLowerCase();
                if (a === "formatblock") {
                    c = tb(b, a);
                    if (c === "" && (a = this.commonNode({
                        "h1,h2,h3,h4,h5,h6,p,div,pre,address": "*"
                    }))) c = a.name;
                    c === "Normal" && (c = "p");
                    return c.toLowerCase()
                }
                if (a === "fontsize") return (a = this.commonNode({
                    "*": ".font-size"
                })) && (c = a.css("font-size")),
                c.toLowerCase();
                if (a === "forecolor") return (a = this.commonNode({
                    "*": ".color"
                })) && (c = a.css("color")),
                c = na(c),
                c === "" && (c = "default"),
                c.toLowerCase();
                if (a === "hilitecolor") return (a = this.commonNode({
                    "*": ".background-color"
                })) && (c = a.css("background-color")),
                c = na(c),
                c === "" && (c = "default"),
                c.toLowerCase();
                return c
            },
            toggle: function(a, b) {
                this.commonNode(b) ? this.remove(b) : this.wrap(a);
                return this.select()
            },
            bold: function() {
                return this.toggle("<strong></strong>", {
                    span: ".font-weight=bold",
                    strong: "*",
                    b: "*"
                })
            },
            italic: function() {
                return this.toggle("<em></em>", {
                    span: ".font-style=italic",
                    em: "*",
                    i: "*"
                })
            },
            underline: function() {
                return this.toggle("<u></u>", {
                    span: ".text-decoration=underline",
                    u: "*"
                })
            },
            strikethrough: function() {
                return this.toggle("<s></s>", {
                    span: ".text-decoration=line-through",
                    s: "*"
                })
            },
            forecolor: function(a) {
                return this.toggle('<span style="color:' + a + ';"></span>', {
                    span: ".color=" + a,
                    font: "color"
                })
            },
            hilitecolor: function(a) {
                return this.toggle('<span style="background-color:' + a + ';"></span>', {
                    span: ".background-color=" + a
                })
            },
            fontsize: function(a) {
                return this.toggle('<span style="font-size:' + a + ';"></span>', {
                    span: ".font-size=" + a,
                    font: "size"
                })
            },
            fontname: function(a) {
                return this.fontfamily(a)
            },
            fontfamily: function(a) {
                return this.toggle('<span style="font-family:' + a + ';"></span>', {
                    span: ".font-family=" + a,
                    font: "face"
                })
            },
            removeformat: function() {
                var a = {
                    "*": ".font-weight,.font-style,.text-decoration,.color,.background-color,.font-size,.font-family,.text-indent"
                };
                m(Mb,
                function(b) {
                    a[b] = "*"
                });
                this.remove(a);
                return this.select()
            },
            inserthtml: function(a, b) {
                function c(a, b) {
                    var b = '<img id="__kindeditor_temp_tag__" width="0" height="0" style="display:none;" />' + b,
                    c = a.get();
                    c.item ? c.item(0).outerHTML = b: c.pasteHTML(b);
                    var d = a.doc.getElementById("__kindeditor_temp_tag__");
                    d.parentNode.removeChild(d);
                    c = sb(c);
                    a.setEnd(c.endContainer, c.endOffset);
                    a.collapse(!1);
                    e.select(!1)
                }
                function d(a, b) {
                    var c = a.doc,
                    d = c.createDocumentFragment();
                    f("@" + b, c).each(function() {
                        d.appendChild(this)
                    });
                    a.deleteContents();
                    a.insertNode(d);
                    a.collapse(!1);
                    e.select(!1)
                }
                var e = this,
                g = e.range;
                if (a === "") return e;
                if (xb(f(g.startContainer))) return e;
                if (o && b) {
                    try {
                        c(g, a)
                    } catch(h) {
                        d(g, a)
                    }
                    return e
                }
                d(g, a);
                return e
            },
            hr: function() {
                return this.inserthtml("<hr />")
            },
            print: function() {
                this.win.print();
                return this
            },
            insertimage: function(a, b, c, d, e, g) {
                b = l(b, "");
                l(e, 0);
                a = '<img src="' + C(a) + '" data-ke-src="' + C(a) + '" ';
                c && (a += 'width="' + C(c) + '" ');
                d && (a += 'height="' + C(d) + '" ');
                b && (a += 'title="' + C(b) + '" ');
                g && (a += 'align="' + C(g) + '" ');
                a += 'alt="' + C(b) + '" ';
                a += "/>";
                return this.inserthtml(a)
            },
            createlink: function(a, b) {
                var c = this.doc,
                d = this.range;
                this.select();
                var e = this.commonNode({
                    a: "*"
                });
                e && !d.isControl() && (d.selectNode(e.get()), this.select());
                e = '<a href="' + C(a) + '" data-ke-src="' + C(a) + '" ';
                b && (e += ' target="' + C(b) + '"');
                if (d.collapsed) return e += ">" + C(a) + "</a>",
                this.inserthtml(e);
                if (d.isControl()) {
                    var g = f(d.startContainer.childNodes[d.startOffset]);
                    e += "></a>";
                    g.after(f(e, c));
                    g.next().append(g);
                    d.selectNode(g[0]);
                    return this.select()
                }
                N(c, "createlink", "__kindeditor_temp_url__");
                f('a[href="__kindeditor_temp_url__"]', c).each(function() {
                    f(this).attr("href", a).attr("data-ke-src", a);
                    b ? f(this).attr("target", b) : f(this).removeAttr("target")
                });
                return this
            },
            unlink: function() {
                var a = this.doc,
                b = this.range;
                this.select();
                if (b.collapsed) {
                    var c = this.commonNode({
                        a: "*"
                    });
                    c && (b.selectNode(c.get()), this.select());
                    N(a, "unlink", null);
                    ba && f(b.startContainer).name === "img" && (a = f(b.startContainer).parent(), a.name === "a" && a.remove(!0))
                } else N(a, "unlink", null);
                return this
            }
        });
        m("formatblock,selectall,justifyleft,justifycenter,justifyright,justifyfull,insertorderedlist,insertunorderedlist,indent,outdent,subscript,superscript".split(","),
        function(a, b) {
            va.prototype[b] = function(a) {
                this.select();
                N(this.doc, b, a); (!o || L(b, "formatblock,selectall,insertorderedlist,insertunorderedlist".split(",")) >= 0) && this.selection();
                return this
            }
        });
        m("cut,copy,paste".split(","),
        function(a, b) {
            va.prototype[b] = function() {
                if (!this.doc.queryCommandSupported(b)) throw "not supported";
                this.select();
                N(this.doc, b, null);
                return this
            }
        });
        f.cmd = yb;
        F(P, {
            init: function(a) {
                var b = this;
                b.name = a.name || "";
                b.doc = a.doc || document;
                b.win = R(b.doc);
                b.x = r(a.x);
                b.y = r(a.y);
                b.z = a.z;
                b.width = r(a.width);
                b.height = r(a.height);
                b.div = f('<div style="display:block;"></div>');
                b.options = a;
                b._alignEl = a.alignEl;
                b.width && b.div.css("width", b.width);
                b.height && b.div.css("height", b.height);
                b.z && b.div.css({
                    position: "absolute",
                    left: b.x,
                    top: b.y,
                    "z-index": b.z
                });
                b.z && (b.x === j || b.y === j) && b.autoPos(b.width, b.height);
                a.cls && b.div.addClass(a.cls);
                a.shadowMode && b.div.addClass("ke-shadow");
                a.css && b.div.css(a.css);
                a.src ? f(a.src).replaceWith(b.div) : f(b.doc.body).append(b.div);
                a.html && b.div.html(a.html);
                if (a.autoScroll) if (o && B < 7 || S) {
                    var c = Z();
                    f(b.win).bind("scroll",
                    function() {
                        var a = Z(),
                        e = a.x - c.x,
                        a = a.y - c.y;
                        b.pos(t(b.x) + e, t(b.y) + a, !1)
                    })
                } else b.div.css("position", "fixed")
            },
            pos: function(a, b, c) {
                c = l(c, !0);
                if (a !== null && (a = a < 0 ? 0 : r(a), this.div.css("left", a), c)) this.x = a;
                if (b !== null && (b = b < 0 ? 0 : r(b), this.div.css("top", b), c)) this.y = b;
                return this
            },
            autoPos: function(a, b) {
                var c = t(a) || 0,
                d = t(b) || 0,
                e = Z();
                if (this._alignEl) {
                    var g = f(this._alignEl),
                    h = g.pos(),
                    c = O(g[0].clientWidth / 2 - c / 2),
                    d = O(g[0].clientHeight / 2 - d / 2);
                    x = c < 0 ? h.x: h.x + c;
                    y = d < 0 ? h.y: h.y + d
                } else h = I(this.doc),
                x = O(e.x + (h.clientWidth - c) / 2),
                y = O(e.y + (h.clientHeight - d) / 2);
                o && B < 7 || S || (x -= e.x, y -= e.y);
                return this.pos(x, y)
            },
            remove: function() {
                var a = this;
                o && B < 7 && f(a.win).unbind("scroll");
                a.div.remove();
                m(a,
                function(b) {
                    a[b] = null
                });
                return this
            },
            show: function() {
                this.div.show();
                return this
            },
            hide: function() {
                this.div.hide();
                return this
            },
            draggable: function(a) {
                var b = this,
                a = a || {};
                a.moveEl = b.div;
                a.moveFn = function(a, d, e, g, f, i) {
                    if ((a += f) < 0) a = 0;
                    if ((d += i) < 0) d = 0;
                    b.pos(a, d)
                };
                Sa(a);
                return b
            }
        });
        f.WidgetClass = P;
        f.widget = Ua;
        var Va = "";
        if (p = document.getElementsByTagName("html")) Va = p[0].dir;
        F(wa, P, {
            init: function(a) {
                function b() {
                    var b = Ta(c.iframe);
                    b.open();
                    if (i) b.domain = document.domain;
                    b.write(Yb(d, e, g, h));
                    b.close();
                    c.win = c.iframe[0].contentWindow;
                    c.doc = b;
                    var k = yb(b);
                    c.afterChange(function() {
                        k.selection()
                    });
                    ba && f(b).click(function(a) {
                        f(a.target).name === "img" && (k.selection(!0), k.range.selectNode(a.target), k.select())
                    });
                    o && f(b).keydown(function(a) {
                        if (a.which == 8) {
                            k.selection();
                            var b = k.range;
                            b.isControl() && (b.collapse(!0), f(b.startContainer.childNodes[b.startOffset]).remove(), a.preventDefault())
                        }
                    });
                    c.cmd = k;
                    c.html(ja(c.srcElement));
                    o ? (b.body.disabled = !0, b.body.contentEditable = !0, b.body.removeAttribute("disabled")) : b.designMode = "on";
                    a.afterCreate && a.afterCreate.call(c)
                }
                var c = this;
                wa.parent.init.call(c, a);
                c.srcElement = f(a.srcElement);
                c.div.addClass("ke-edit");
                c.designMode = l(a.designMode, !0);
                c.beforeGetHtml = a.beforeGetHtml;
                c.beforeSetHtml = a.beforeSetHtml;
                c.afterSetHtml = a.afterSetHtml;
                var d = l(a.themesPath, ""),
                e = a.bodyClass,
                g = a.cssPath,
                h = a.cssData,
                i = location.host.replace(/:\d+/, "") !== document.domain,
                k = "document.open();" + (i ? 'document.domain="' + document.domain + '";': "") + "document.close();",
                k = o ? ' src="javascript:void(function(){' + encodeURIComponent(k) + '}())"': "";
                c.iframe = f('<iframe class="ke-edit-iframe" hidefocus="true" frameborder="0"' + k + "></iframe>").css("width", "100%");
                c.textarea = f('<textarea class="ke-edit-textarea" hidefocus="true"></textarea>').css("width", "100%");
                c.width && c.setWidth(c.width);
                c.height && c.setHeight(c.height);
                c.designMode ? c.textarea.hide() : c.iframe.hide();
                i && c.iframe.bind("load",
                function() {
                    c.iframe.unbind("load");
                    o ? b() : setTimeout(b, 0)
                });
                c.div.append(c.iframe);
                c.div.append(c.textarea);
                c.srcElement.hide(); ! i && b()
            },
            setWidth: function(a) {
                this.div.css("width", r(a));
                return this
            },
            setHeight: function(a) {
                a = r(a);
                this.div.css("height", a);
                this.iframe.css("height", a);
                if (o && B < 8 || S) a = r(t(a) - 2);
                this.textarea.css("height", a);
                return this
            },
            remove: function() {
                var a = this.doc;
                f(a.body).unbind();
                f(a).unbind();
                f(this.win).unbind();
                ja(this.srcElement, this.html());
                this.srcElement.show();
                a.write("");
                this.iframe.unbind();
                this.textarea.unbind();
                wa.parent.remove.call(this)
            },
            html: function(a, b) {
                var c = this.doc;
                if (this.designMode) {
                    c = c.body;
                    if (a === j) return a = b ? "<!doctype html><html>" + c.parentNode.innerHTML + "</html>": c.innerHTML,
                    this.beforeGetHtml && (a = this.beforeGetHtml(a)),
                    ka && a == "<br />" && (a = ""),
                    a;
                    this.beforeSetHtml && (a = this.beforeSetHtml(a));
                    f(c).html(a);
                    this.afterSetHtml && this.afterSetHtml();
                    return this
                }
                if (a === j) return this.textarea.val();
                this.textarea.val(a);
                return this
            },
            design: function(a) {
                if (a === j ? !this.designMode: a) {
                    if (!this.designMode) a = this.html(),
                    this.designMode = !0,
                    this.html(a),
                    this.textarea.hide(),
                    this.iframe.show()
                } else if (this.designMode) a = this.html(),
                this.designMode = !1,
                this.html(a),
                this.iframe.hide(),
                this.textarea.show();
                return this.focus()
            },
            focus: function() {
                this.designMode ? this.win.focus() : this.textarea[0].focus();
                return this
            },
            blur: function() {
                if (o) {
                    var a = f('<input type="text" style="float:left;width:0;height:0;padding:0;margin:0;border:0;" value="" />', this.div);
                    this.div.append(a);
                    a[0].focus();
                    a.remove()
                } else this.designMode ? this.win.blur() : this.textarea[0].blur();
                return this
            },
            afterChange: function(a) {
                function b(b) {
                    setTimeout(function() {
                        a(b)
                    },
                    1)
                }
                var c = this.doc,
                d = c.body;
                f(c).keyup(function(b) { ! b.ctrlKey && !b.altKey && ab[b.which] && a(b)
                });
                f(c).mouseup(a).contextmenu(a);
                f(this.win).blur(a);
                f(d).bind("paste", b);
                f(d).bind("cut", b);
                return this
            }
        });
        f.edit = zb;
        f.iframeDoc = Ta;
        F(Wa, P, {
            init: function(a) {
                function b(a) {
                    a = f(a);
                    if (a.hasClass("ke-outline")) return a;
                    if (a.hasClass("ke-toolbar-icon")) return a.parent()
                }
                function c(a, c) {
                    var d = b(a.target);
                    if (d && !d.hasClass("ke-disabled") && !d.hasClass("ke-selected")) d[c]("ke-on")
                }
                var d = this;
                Wa.parent.init.call(d, a);
                d.disableMode = l(a.disableMode, !1);
                d.noDisableItemMap = u(l(a.noDisableItems, []));
                d._itemMap = {};
                d.div.addClass("ke-toolbar").bind("contextmenu,mousedown,mousemove",
                function(a) {
                    a.preventDefault()
                }).attr("unselectable", "on");
                d.div.mouseover(function(a) {
                    c(a, "addClass")
                }).mouseout(function(a) {
                    c(a, "removeClass")
                }).click(function(a) {
                    var c = b(a.target);
                    c && !c.hasClass("ke-disabled") && d.options.click.call(this, a, c.attr("data-name"))
                })
            },
            get: function(a) {
                if (this._itemMap[a]) return this._itemMap[a];
                return this._itemMap[a] = f("span.ke-icon-" + a, this.div).parent()
            },
            select: function(a) {
                Ab.call(this, a,
                function(a) {
                    a.addClass("ke-selected")
                });
                return self
            },
            unselect: function(a) {
                Ab.call(this, a,
                function(a) {
                    a.removeClass("ke-selected").removeClass("ke-on")
                });
                return self
            },
            enable: function(a) {
                if (a = a.get ? a: this.get(a)) a.removeClass("ke-disabled"),
                a.opacity(1);
                return this
            },
            disable: function(a) {
                if (a = a.get ? a: this.get(a)) a.removeClass("ke-selected").addClass("ke-disabled"),
                a.opacity(0.5);
                return this
            },
            disableAll: function(a, b) {
                var c = this,
                d = c.noDisableItemMap;
                b && (d = u(b)); (a === j ? !c.disableMode: a) ? (f("span.ke-outline", c.div).each(function() {
                    var a = f(this),
                    b = a[0].getAttribute("data-name", 2);
                    d[b] || c.disable(a)
                }), c.disableMode = !0) : (f("span.ke-outline", c.div).each(function() {
                    var a = f(this),
                    b = a[0].getAttribute("data-name", 2);
                    d[b] || c.enable(a)
                }), c.disableMode = !1);
                return c
            }
        });
        f.toolbar = Bb;
        F(xa, P, {
            init: function(a) {
                a.z = a.z || 811213;
                xa.parent.init.call(this, a);
                this.centerLineMode = l(a.centerLineMode, !0);
                this.div.addClass("ke-menu").bind("click,mousedown",
                function(a) {
                    a.stopPropagation()
                }).attr("unselectable", "on")
            },
            addItem: function(a) {
                if (a.title === "-") this.div.append(f('<div class="ke-menu-separator"></div>'));
                else {
                    var b = f('<div class="ke-menu-item" unselectable="on"></div>'),
                    c = f('<div class="ke-inline-block ke-menu-item-left"></div>'),
                    d = f('<div class="ke-inline-block ke-menu-item-right"></div>'),
                    e = r(a.height),
                    g = l(a.iconClass, "");
                    this.div.append(b);
                    e && (b.css("height", e), d.css("line-height", e));
                    var h;
                    this.centerLineMode && (h = f('<div class="ke-inline-block ke-menu-item-center"></div>'), e && h.css("height", e));
                    b.mouseover(function() {
                        f(this).addClass("ke-menu-item-on");
                        h && h.addClass("ke-menu-item-center-on")
                    }).mouseout(function() {
                        f(this).removeClass("ke-menu-item-on");
                        h && h.removeClass("ke-menu-item-center-on")
                    }).click(function(b) {
                        a.click.call(f(this));
                        b.stopPropagation()
                    }).append(c);
                    h && b.append(h);
                    b.append(d);
                    a.checked && (g = "ke-icon-checked");
                    g !== "" && c.html('<span class="ke-inline-block ke-toolbar-icon ke-toolbar-icon-url ' + g + '"></span>');
                    d.html(a.title);
                    return this
                }
            },
            remove: function() {
                this.options.beforeRemove && this.options.beforeRemove.call(this);
                f(".ke-menu-item", this.div[0]).unbind();
                xa.parent.remove.call(this);
                return this
            }
        });
        f.menu = Xa;
        F(ya, P, {
            init: function(a) {
                a.z = a.z || 811213;
                ya.parent.init.call(this, a);
                var b = a.colors || [["#E53333", "#E56600", "#FF9900", "#64451D", "#DFC5A4", "#FFE500"], ["#009900", "#006600", "#99BB00", "#B8D100", "#60D978", "#00D5FF"], ["#337FE5", "#003399", "#4C33E5", "#9933E5", "#CC33E5", "#EE33EE"], ["#FFFFFF", "#CCCCCC", "#999999", "#666666", "#333333", "#000000"]];
                this.selectedColor = (a.selectedColor || "").toLowerCase();
                this._cells = [];
                this.div.addClass("ke-colorpicker").bind("click,mousedown",
                function(a) {
                    a.stopPropagation()
                }).attr("unselectable", "on");
                a = this.doc.createElement("table");
                this.div.append(a);
                a.className = "ke-colorpicker-table";
                a.cellPadding = 0;
                a.cellSpacing = 0;
                a.border = 0;
                var c = a.insertRow(0),
                d = c.insertCell(0);
                d.colSpan = b[0].length;
                this._addAttr(d, "", "ke-colorpicker-cell-top");
                for (var e = 0; e < b.length; e++) for (var c = a.insertRow(e + 1), g = 0; g < b[e].length; g++) d = c.insertCell(g),
                this._addAttr(d, b[e][g], "ke-colorpicker-cell")
            },
            _addAttr: function(a, b, c) {
                var d = this,
                a = f(a).addClass(c);
                d.selectedColor === b.toLowerCase() && a.addClass("ke-colorpicker-cell-selected");
                a.attr("title", b || d.options.noColor);
                a.mouseover(function() {
                    f(this).addClass("ke-colorpicker-cell-on")
                });
                a.mouseout(function() {
                    f(this).removeClass("ke-colorpicker-cell-on")
                });
                a.click(function(a) {
                    a.stop();
                    d.options.click.call(f(this), b)
                });
                b ? a.append(f('<div class="ke-colorpicker-cell-color" unselectable="on"></div>').css("background-color", b)) : a.html(d.options.noColor);
                f(a).attr("unselectable", "on");
                d._cells.push(a)
            },
            remove: function() {
                m(this._cells,
                function() {
                    this.unbind()
                });
                ya.parent.remove.call(this);
                return this
            }
        });
        f.colorpicker = Cb;
        F(Db, {
            init: function(a) {
                var b = f(a.button),
                c = a.fieldName || "file",
                d = a.url || "",
                e = b.val(),
                g = b[0].className || "",
                h = a.target || "kindeditor_upload_iframe_" + (new Date).getTime();
                a.afterError = a.afterError ||
                function(a) {
                    alert(a)
                };
                c = ['<div class="ke-inline-block ' + g + '">', a.target ? "": '<iframe name="' + h + '" style="display:none;"></iframe>', a.form ? '<div class="ke-upload-area">': '<form class="ke-upload-area ke-form" method="post" enctype="multipart/form-data" target="' + h + '" action="' + d + '">', '<span class="ke-button-common">', '<input type="button" class="ke-button-common ke-button" value="' + e + '" />', "</span>", '<input type="file" class="ke-upload-file" name="' + c + '" tabindex="-1" />', a.form ? "</div>": "</form>", "</div>"].join("");
                c = f(c, b.doc);
                b.hide();
                b.before(c);
                this.div = c;
                this.button = b;
                this.iframe = a.target ? f('iframe[name="' + h + '"]') : f("iframe", c);
                this.form = a.form ? f(a.form) : f("form", c);
                b = a.width || f(".ke-button-common", c).width();
                this.fileBox = f(".ke-upload-file", c).width(b);
                this.options = a
            },
            submit: function() {
                var a = this,
                b = a.iframe;
                b.bind("load",
                function() {
                    b.unbind();
                    var c = document.createElement("form");
                    a.fileBox.before(c);
                    f(c).append(a.fileBox);
                    c.reset();
                    f(c).remove(!0);
                    var c = f.iframeDoc(b),
                    d = c.getElementsByTagName("pre")[0],
                    e = "",
                    g,
                    e = d ? d.innerHTML: c.body.innerHTML;
                    b[0].src = "javascript:false";
                    try {
                        g = f.json(e)
                    } catch(h) {
                        a.options.afterError.call(a, "<!doctype html><html>" + c.body.parentNode.innerHTML + "</html>")
                    }
                    g && a.options.afterUpload.call(a, g)
                });
                a.form[0].submit();
                return a
            },
            remove: function() {
                this.fileBox && this.fileBox.unbind();
                this.iframe.remove();
                this.div.remove();
                this.button.show();
                return this
            }
        });
        f.uploadbutton = function(a) {
            return new Db(a)
        };
        F(za, P, {
            init: function(a) {
                var b = l(a.shadowMode, !0);
                a.z = a.z || 811213;
                a.shadowMode = !1;
                za.parent.init.call(this, a);
                var c = a.title,
                d = f(a.body, this.doc),
                e = a.previewBtn,
                g = a.yesBtn,
                h = a.noBtn,
                i = a.closeBtn,
                k = l(a.showMask, !0);
                this.div.addClass("ke-dialog").bind("click,mousedown",
                function(a) {
                    a.stopPropagation()
                });
                var n = f('<div class="ke-dialog-content"></div>').appendTo(this.div);
                o && B < 7 ? this.iframeMask = f('<iframe src="about:blank" class="ke-dialog-shadow"></iframe>').appendTo(this.div) : b && f('<div class="ke-dialog-shadow"></div>').appendTo(this.div);
                b = f('<div class="ke-dialog-header"></div>');
                n.append(b);
                b.html(c);
                this.closeIcon = f('<span class="ke-dialog-icon-close" title="' + i.name + '"></span>').click(i.click);
                b.append(this.closeIcon);
                this.draggable({
                    clickEl: b,
                    beforeDrag: a.beforeDrag
                });
                a = f('<div class="ke-dialog-body"></div>');
                n.append(a);
                a.append(d);
                var j = f('<div class="ke-dialog-footer"></div>'); (e || g || h) && n.append(j);
                m([{
                    btn: e,
                    name: "preview"
                },
                {
                    btn: g,
                    name: "yes"
                },
                {
                    btn: h,
                    name: "no"
                }],
                function() {
                    if (this.btn) {
                        var a = this.btn,
                        a = a || {},
                        b = a.name || "",
                        c = f('<span class="ke-button-common ke-button-outer" title="' + b + '"></span>'),
                        b = f('<input class="ke-button-common ke-button" type="button" value="' + b + '" />');
                        a.click && b.click(a.click);
                        c.append(b);
                        c.addClass("ke-dialog-" + this.name);
                        j.append(c)
                    }
                });
                this.height && a.height(t(this.height) - b.height() - j.height());
                this.div.width(this.div.width());
                this.div.height(this.div.height());
                this.mask = null;
                if (k) d = I(this.doc),
                this.mask = Ua({
                    x: 0,
                    y: 0,
                    z: this.z - 1,
                    cls: "ke-dialog-mask",
                    width: Math.max(d.scrollWidth, d.clientWidth),
                    height: Math.max(d.scrollHeight, d.clientHeight)
                });
                this.autoPos(this.div.width(), this.div.height());
                this.footerDiv = j;
                this.bodyDiv = a;
                this.headerDiv = b;
                this.isLoading = !1
            },
            setMaskIndex: function(a) {
                this.mask.div.css("z-index", a)
            },
            showLoading: function(a) {
                var a = l(a, ""),
                b = this.bodyDiv;
                this.loading = f('<div class="ke-dialog-loading"><div class="ke-inline-block ke-dialog-loading-content" style="margin-top:' + Math.round(b.height() / 3) + 'px;">' + a + "</div></div>").width(b.width()).height(b.height()).css("top", this.headerDiv.height() + "px");
                b.css("visibility", "hidden").after(this.loading);
                this.isLoading = !0;
                return this
            },
            hideLoading: function() {
                this.loading && this.loading.remove();
                this.bodyDiv.css("visibility", "visible");
                this.isLoading = !1;
                return this
            },
            remove: function() {
                this.options.beforeRemove && this.options.beforeRemove.call(this);
                this.mask && this.mask.remove();
                this.iframeMask && this.iframeMask.remove();
                this.closeIcon.unbind();
                f("input", this.div).unbind();
                f("button", this.div).unbind();
                this.footerDiv.unbind();
                this.bodyDiv.unbind();
                this.headerDiv.unbind();
                f("iframe", this.div).each(function() {
                    f(this).remove()
                });
                za.parent.remove.call(this);
                return this
            }
        });
        f.dialog = Eb;
        f.tabs = function(a) {
            var b = Ua(a),
            c = b.remove,
            d = a.afterSelect,
            a = b.div,
            e = [];
            a.addClass("ke-tabs").bind("contextmenu,mousedown,mousemove",
            function(a) {
                a.preventDefault()
            });
            var g = f('<ul class="ke-tabs-ul ke-clearfix"></ul>');
            a.append(g);
            b.add = function(a) {
                var b = f('<li class="ke-tabs-li">' + a.title + "</li>");
                b.data("tab", a);
                e.push(b);
                g.append(b)
            };
            b.selectedIndex = 0;
            b.select = function(a) {
                b.selectedIndex = a;
                m(e,
                function(c, d) {
                    d.unbind();
                    c === a ? (d.addClass("ke-tabs-li-selected"), f(d.data("tab").panel).show("")) : (d.removeClass("ke-tabs-li-selected").removeClass("ke-tabs-li-on").mouseover(function() {
                        f(this).addClass("ke-tabs-li-on")
                    }).mouseout(function() {
                        f(this).removeClass("ke-tabs-li-on")
                    }).click(function() {
                        b.select(c)
                    }), f(d.data("tab").panel).hide())
                });
                d && d.call(b, a)
            };
            b.remove = function() {
                m(e,
                function() {
                    this.remove()
                });
                g.remove();
                c.call(b)
            };
            return b
        };
        f.loadScript = Ya;
        f.loadStyle = Za;
        f.ajax = function(a, b, c, d, e) {
            var c = c || "GET",
            e = e || "json",
            g = z.XMLHttpRequest ? new z.XMLHttpRequest: new ActiveXObject("Microsoft.XMLHTTP");
            g.open(c, a, !0);
            g.onreadystatechange = function() {
                if (g.readyState == 4 && g.status == 200 && b) {
                    var a = A(g.responseText);
                    e == "json" && (a = cb(a));
                    b(a)
                }
            };
            if (c == "POST") {
                var f = [];
                m(d,
                function(a, b) {
                    f.push(encodeURIComponent(a) + "=" + encodeURIComponent(b))
                });
                try {
                    g.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                } catch(i) {}
                g.send(f.join("&"))
            } else g.send(null)
        };
        var T = {},
        K = {};
        la.prototype = {
            lang: function(a) {
                return Ib(a, this.langType)
            },
            loadPlugin: function(a, b) {
                var c = this;
                if (T[a]) {
                    if (c._calledPlugins[a]) return b && b.call(c),
                    c;
                    T[a].call(c, KindEditor);
                    b && b.call(c);
                    c._calledPlugins[a] = !0;
                    return c
                }
                if (c.isLoading) return c;
                c.isLoading = !0;
                Ya(c.pluginsPath + a + "/" + a + ".js?ver=" + encodeURIComponent(f.DEBUG ? Ba: Ca),
                function() {
                    c.isLoading = !1;
                    T[a] && c.loadPlugin(a, b)
                });
                return c
            },
            handler: function(a, b) {
                var c = this;
                c._handlers[a] || (c._handlers[a] = []);
                if (bb(b)) return c._handlers[a].push(b),
                c;
                m(c._handlers[a],
                function() {
                    b = this.call(c, b)
                });
                return b
            },
            clickToolbar: function(a, b) {
                var c = this,
                d = "clickToolbar" + a;
                if (b === j) {
                    if (c._handlers[d]) return c.handler(d);
                    c.loadPlugin(a,
                    function() {
                        c.handler(d)
                    });
                    return c
                }
                return c.handler(d, b)
            },
            updateState: function() {
                var a = this;
                m("justifyleft,justifycenter,justifyright,justifyfull,insertorderedlist,insertunorderedlist,subscript,superscript,bold,italic,underline,strikethrough".split(","),
                function(b, c) {
                    a.cmd.state(c) ? a.toolbar.select(c) : a.toolbar.unselect(c)
                });
                return a
            },
            addContextmenu: function(a) {
                this._contextmenus.push(a);
                return this
            },
            afterCreate: function(a) {
                return this.handler("afterCreate", a)
            },
            beforeRemove: function(a) {
                return this.handler("beforeRemove", a)
            },
            beforeGetHtml: function(a) {
                return this.handler("beforeGetHtml", a)
            },
            beforeSetHtml: function(a) {
                return this.handler("beforeSetHtml", a)
            },
            afterSetHtml: function(a) {
                return this.handler("afterSetHtml", a)
            },
            create: function() {
                function a() {
                    j.height() === 0 ? setTimeout(a, 100) : c.resize(e, g)
                }
                function b(a, b, d) {
                    d = l(d, !0);
                    if (a && a >= c.minWidth && (c.resize(a, null), d)) c.width = r(a);
                    if (b && b >= c.minHeight && (c.resize(null, b), d)) c.height = r(b)
                }
                var c = this,
                d = c.fullscreenMode;
                if (c.isCreated) return c;
                d ? I().style.overflow = "hidden": I().style.overflow = "";
                var e = d ? I().clientWidth + "px": c.width,
                g = d ? I().clientHeight + "px": c.height;
                if (o && B < 8 || S) g = r(t(g) + 2);
                var h = c.container = f(c.layout);
                d ? f(document.body).append(h) : c.srcElement.before(h);
                var i = f(".toolbar", h),
                k = f(".edit", h),
                j = c.statusbar = f(".statusbar", h);
                h.removeClass("container").addClass("ke-container ke-container-" + c.themeType).css("width", e);
                if (d) {
                    h.css({
                        position: "absolute",
                        left: 0,
                        top: 0,
                        "z-index": 811211
                    });
                    if (!ka) c._scrollPos = Z();
                    z.scrollTo(0, 0);
                    f(document.body).css({
                        height: "1px",
                        overflow: "hidden"
                    });
                    f(document.body.parentNode).css("overflow", "hidden");
                    c._fullscreenExecuted = !0
                } else c._fullscreenExecuted && (f(document.body).css({
                    height: "",
                    overflow: ""
                }), f(document.body.parentNode).css("overflow", "")),
                c._scrollPos && z.scrollTo(c._scrollPos.x, c._scrollPos.y);
                var m = [];
                f.each(c.items,
                function(a, b) {
                    b == "|" ? m.push('<span class="ke-inline-block ke-separator"></span>') : b == "/" ? m.push('<div class="ke-hr"></div>') : (m.push('<span class="ke-outline" data-name="' + b + '" title="' + c.lang(b) + '" unselectable="on">'), m.push('<span class="ke-toolbar-icon ke-toolbar-icon-url ke-icon-' + b + '" unselectable="on"></span></span>'))
                });
                var i = c.toolbar = Bb({
                    src: i,
                    html: m.join(""),
                    noDisableItems: c.noDisableItems,
                    click: function(a, b) {
                        a.stop();
                        if (c.menu) {
                            var d = c.menu.name;
                            c.hideMenu();
                            if (d === b) return
                        }
                        c.clickToolbar(b)
                    }
                }),
                q = t(g) - i.div.height(),
                p = c.edit = zb({
                    height: q > 0 && t(g) > c.minHeight ? q: c.minHeight,
                    src: k,
                    srcElement: c.srcElement,
                    designMode: c.designMode,
                    themesPath: c.themesPath,
                    bodyClass: c.bodyClass,
                    cssPath: c.cssPath,
                    cssData: c.cssData,
                    beforeGetHtml: function(a) {
                        a = c.beforeGetHtml(a);
                        return Q(a, c.filterMode ? c.htmlTags: null, c.urlType, c.wellFormatMode, c.indentChar)
                    },
                    beforeSetHtml: function(a) {
                        a = Q(a, c.filterMode ? c.htmlTags: null, "", !1);
                        return c.beforeSetHtml(a)
                    },
                    afterSetHtml: function() {
                        c.edit = p = this;
                        c.afterSetHtml()
                    },
                    afterCreate: function() {
                        c.edit = p = this;
                        c.cmd = p.cmd;
                        c._docMousedownFn = function() {
                            c.menu && c.hideMenu()
                        };
                        f(p.doc, document).mousedown(c._docMousedownFn);
                        Zb.call(c);
                        $b.call(c);
                        ac.call(c);
                        bc.call(c);
                        p.afterChange(function() {
                            p.designMode && (c.updateState(), c.addBookmark(), c.options.afterChange && c.options.afterChange.call(c))
                        });
                        p.textarea.keyup(function(a) { ! a.ctrlKey && !a.altKey && Ob[a.which] && c.options.afterChange && c.options.afterChange.call(c)
                        });
                        c.readonlyMode && c.readonly();
                        c.isCreated = !0;
                        if (c.initContent === "") c.initContent = c.html();
                        c.afterCreate();
                        c.options.afterCreate && c.options.afterCreate.call(c)
                    }
                });
                j.removeClass("statusbar").addClass("ke-statusbar").append('<span class="ke-inline-block ke-statusbar-center-icon"></span>').append('<span class="ke-inline-block ke-statusbar-right-icon"></span>');
                f(z).unbind("resize");
                a();
                d ? (f(z).bind("resize",
                function() {
                    c.isCreated && b(I().clientWidth, I().clientHeight, !1)
                }), i.select("fullscreen"), j.first().css("visibility", "hidden"), j.last().css("visibility", "hidden")) : (ka && f(z).bind("scroll",
                function() {
                    c._scrollPos = Z()
                }), c.resizeType > 0 ? Sa({
                    moveEl: h,
                    clickEl: j,
                    moveFn: function(a, c, d, e, g, f) {
                        e += f;
                        b(null, e)
                    }
                }) : j.first().css("visibility", "hidden"), c.resizeType === 2 ? Sa({
                    moveEl: h,
                    clickEl: j.last(),
                    moveFn: function(a, c, d, e, g, f) {
                        d += g;
                        e += f;
                        b(d, e)
                    }
                }) : j.last().css("visibility", "hidden"));
                return c
            },
            remove: function() {
                var a = this;
                if (!a.isCreated) return a;
                a.beforeRemove();
                a.menu && a.hideMenu();
                m(a.dialogs,
                function() {
                    a.hideDialog()
                });
                f(document).unbind("mousedown", a._docMousedownFn);
                a.toolbar.remove();
                a.edit.remove();
                a.statusbar.last().unbind();
                a.statusbar.unbind();
                a.container.remove();
                a.container = a.toolbar = a.edit = a.menu = null;
                a.dialogs = [];
                a.isCreated = !1;
                return a
            },
            resize: function(a, b) {
                a !== null && t(a) > this.minWidth && this.container.css("width", r(a));
                b !== null && (b = t(b) - this.toolbar.div.height() - this.statusbar.height(), b > 0 && t(b) > this.minHeight && this.edit.setHeight(b));
                return this
            },
            select: function() {
                this.isCreated && this.cmd.select();
                return this
            },
            html: function(a) {
                if (a === j) return this.isCreated ? this.edit.html() : ja(this.srcElement);
                this.isCreated ? this.edit.html(a) : ja(this.srcElement, a);
                return this
            },
            fullHtml: function() {
                return this.isCreated ? this.edit.html(j, !0) : ""
            },
            text: function(a) {
                return a === j ? A(this.html().replace(/<(?!img|embed).*?>/ig, "").replace(/&nbsp;/ig, " ")) : this.html(C(a))
            },
            isEmpty: function() {
                return A(this.text().replace(/\r\n|\n|\r/, "")) === ""
            },
            isDirty: function() {
                return A(this.initContent.replace(/\r\n|\n|\r|t/g, "")) !== A(this.html().replace(/\r\n|\n|\r|t/g, ""))
            },
            selectedHtml: function() {
                return this.isCreated ? this.cmd.range.html() : ""
            },
            count: function(a) {
                a = (a || "html").toLowerCase();
                if (a === "html") return U($a(this.html())).length;
                if (a === "text") return this.text().replace(/<(?:img|embed).*?>/ig, "K").replace(/\r\n|\n|\r/g, "").length;
                return 0
            },
            exec: function(a) {
                var a = a.toLowerCase(),
                b = this.cmd,
                c = L(a, "selectall,copy,paste,print".split(",")) < 0;
                c && this.addBookmark(!1);
                b[a].apply(b, Fa(arguments, 1));
                c && (this.updateState(), this.addBookmark(!1), this.options.afterChange && this.options.afterChange.call(this));
                return this
            },
            insertHtml: function(a) {
                if (!this.isCreated) return this;
                a = this.beforeSetHtml(a);
                this.exec("inserthtml", a);
                return this
            },
            appendHtml: function(a) {
                this.html(this.html() + a);
                if (this.isCreated) a = this.cmd,
                a.range.selectNodeContents(a.doc.body).collapse(!1),
                a.select();
                return this
            },
            sync: function() {
                ja(this.srcElement, this.html());
                return this
            },
            focus: function() {
                this.isCreated ? this.edit.focus() : this.srcElement[0].focus();
                return this
            },
            blur: function() {
                this.isCreated ? this.edit.blur() : this.srcElement[0].blur();
                return this
            },
            addBookmark: function(a) {
                var a = l(a, !0),
                b = this.edit,
                c = b.doc.body,
                d = $a(c.innerHTML);
                if (a && this._undoStack.length > 0 && Math.abs(d.length - U(this._undoStack[this._undoStack.length - 1].html).length) < this.minChangeSize) return this;
                b.designMode && !this._firstAddBookmark ? (b = this.cmd.range, a = b.createBookmark(!0), a.html = $a(c.innerHTML), b.moveToBookmark(a)) : a = {
                    html: d
                };
                this._firstAddBookmark = !1;
                Jb(this._undoStack, a);
                return this
            },
            undo: function() {
                return Kb.call(this, this._undoStack, this._redoStack)
            },
            redo: function() {
                return Kb.call(this, this._redoStack, this._undoStack)
            },
            fullscreen: function(a) {
                this.fullscreenMode = a === j ? !this.fullscreenMode: a;
                return this.remove().create()
            },
            readonly: function(a) {
                var a = l(a, !0),
                b = this,
                c = b.edit,
                d = c.doc;
                b.designMode ? b.toolbar.disableAll(a, []) : m(b.noDisableItems,
                function() {
                    b.toolbar[a ? "disable": "enable"](this)
                });
                o ? d.body.contentEditable = !a: d.designMode = a ? "off": "on";
                c.textarea[0].disabled = a
            },
            createMenu: function(a) {
                var b = this.toolbar.get(a.name),
                c = b.pos();
                a.x = c.x;
                a.y = c.y + b.height();
                a.shadowMode = l(a.shadowMode, this.shadowMode);
                a.selectedColor !== j ? (a.cls = "ke-colorpicker-" + this.themeType, a.noColor = this.lang("noColor"), this.menu = Cb(a)) : (a.cls = "ke-menu-" + this.themeType, a.centerLineMode = !1, this.menu = Xa(a));
                return this.menu
            },
            hideMenu: function() {
                this.menu.remove();
                this.menu = null;
                return this
            },
            hideContextmenu: function() {
                this.contextmenu.remove();
                this.contextmenu = null;
                return this
            },
            createDialog: function(a) {
                var b = this;
                a.autoScroll = l(a.autoScroll, !0);
                a.shadowMode = l(a.shadowMode, b.shadowMode);
                a.closeBtn = l(a.closeBtn, {
                    name: b.lang("close"),
                    click: function() {
                        b.hideDialog();
                        o && b.cmd && b.cmd.select()
                    }
                });
                a.noBtn = l(a.noBtn, {
                    name: b.lang(a.yesBtn ? "no": "close"),
                    click: function() {
                        b.hideDialog();
                        o && b.cmd && b.cmd.select()
                    }
                });
                if (b.dialogAlignType != "page") a.alignEl = b.container;
                a.cls = "ke-dialog-" + b.themeType;
                if (b.dialogs.length > 0) {
                    var c = b.dialogs[b.dialogs.length - 1];
                    b.dialogs[0].setMaskIndex(c.z + 2);
                    a.z = c.z + 3;
                    a.showMask = !1
                }
                a = Eb(a);
                b.dialogs.push(a);
                return a
            },
            hideDialog: function() {
                this.dialogs.length > 0 && this.dialogs.pop().remove();
                this.dialogs.length > 0 && this.dialogs[0].setMaskIndex(this.dialogs[this.dialogs.length - 1].z - 1);
                return this
            },
            errorDialog: function(a) {
                var b = this.createDialog({
                    width: 750,
                    title: this.lang("uploadError"),
                    body: '<div style="padding:10px 20px;"><iframe frameborder="0" style="width:708px;height:400px;"></iframe></div>'
                }),
                b = f("iframe", b.div),
                c = f.iframeDoc(b);
                c.open();
                c.write(a);
                c.close();
                f(c.body).css("background-color", "#FFF");
                b[0].contentWindow.focus();
                return this
            }
        };
        _instances = [];
        o && B < 7 && N(document, "BackgroundImageCache", !0);
        f.EditorClass = la;
        f.editor = function(a) {
            return new la(a)
        };
        f.create = Lb;
        f.instances = _instances;
        f.plugin = Gb;
        f.lang = Ib;
        Gb("core",
        function(a) {
            var b = this,
            c = {
                undo: "Z",
                redo: "Y",
                bold: "B",
                italic: "I",
                underline: "U",
                print: "P",
                selectall: "A"
            };
            b.afterSetHtml(function() {
                b.options.afterChange && b.options.afterChange.call(b)
            });
            b.afterCreate(function() {
                if (b.syncType == "form") {
                    for (var c = a(b.srcElement), d = !1; c = c.parent();) if (c.name == "form") {
                        d = !0;
                        break
                    }
                    if (d) {
                        c.bind("submit",
                        function() {
                            b.sync();
                            a(z).bind("unload",
                            function() {
                                b.edit.textarea.remove()
                            })
                        });
                        var f = a('[type="reset"]', c);
                        f.click(function() {
                            b.html(b.initContent);
                            b.cmd.selection()
                        });
                        b.beforeRemove(function() {
                            c.unbind();
                            f.unbind()
                        })
                    }
                }
            });
            b.clickToolbar("source",
            function() {
                b.edit.designMode ? (b.toolbar.disableAll(!0), b.edit.design(!1), b.toolbar.select("source")) : (b.toolbar.disableAll(!1), b.edit.design(!0), b.toolbar.unselect("source"));
                b.designMode = b.edit.designMode
            });
            b.afterCreate(function() {
                b.designMode || b.toolbar.disableAll(!0).select("source")
            });
            b.clickToolbar("fullscreen",
            function() {
                b.fullscreen()
            });
            if (b.fullscreenShortcut) {
                var d = !1;
                b.afterCreate(function() {
                    a(b.edit.doc, b.edit.textarea).keyup(function(a) {
                        a.which == 27 && setTimeout(function() {
                            b.fullscreen()
                        },
                        0)
                    });
                    if (d) {
                        if (o && !b.designMode) return;
                        b.focus()
                    }
                    d || (d = !0)
                })
            }
            m("undo,redo".split(","),
            function(a, d) {
                c[d] && b.afterCreate(function() {
                    Ga(this.edit.doc, c[d],
                    function() {
                        b.clickToolbar(d)
                    })
                });
                b.clickToolbar(d,
                function() {
                    b[d]()
                })
            });
            b.clickToolbar("formatblock",
            function() {
                var a = b.lang("formatblock.formatBlock"),
                c = {
                    h1: 28,
                    h2: 24,
                    h3: 18,
                    H4: 14,
                    p: 12
                },
                d = b.cmd.val("formatblock"),
                f = b.createMenu({
                    name: "formatblock",
                    width: b.langType == "en" ? 200 : 150
                });
                m(a,
                function(a, e) {
                    var j = "font-size:" + c[a] + "px;";
                    a.charAt(0) === "h" && (j += "font-weight:bold;");
                    f.addItem({
                        title: '<span style="' + j + '" unselectable="on">' + e + "</span>",
                        height: c[a] + 12,
                        checked: d === a || d === e,
                        click: function() {
                            b.select().exec("formatblock", "<" + a + ">").hideMenu()
                        }
                    })
                })
            });
            b.clickToolbar("fontname",
            function() {
                var a = b.cmd.val("fontname"),
                c = b.createMenu({
                    name: "fontname",
                    width: 150
                });
                m(b.lang("fontname.fontName"),
                function(d, f) {
                    c.addItem({
                        title: '<span style="font-family: ' + d + ';" unselectable="on">' + f + "</span>",
                        checked: a === d.toLowerCase() || a === f.toLowerCase(),
                        click: function() {
                            b.exec("fontname", d).hideMenu()
                        }
                    })
                })
            });
            b.clickToolbar("fontsize",
            function() {
                var a = b.cmd.val("fontsize"),
                c = b.createMenu({
                    name: "fontsize",
                    width: 150
                });
                m(b.fontSizeTable,
                function(d, f) {
                    c.addItem({
                        title: '<span style="font-size:' + f + ';" unselectable="on">' + f + "</span>",
                        height: t(f) + 12,
                        checked: a === f,
                        click: function() {
                            b.exec("fontsize", f).hideMenu()
                        }
                    })
                })
            });
            m("forecolor,hilitecolor".split(","),
            function(a, c) {
                b.clickToolbar(c,
                function() {
                    b.createMenu({
                        name: c,
                        selectedColor: b.cmd.val(c) || "default",
                        colors: b.colorTable,
                        click: function(a) {
                            b.exec(c, a).hideMenu()
                        }
                    })
                })
            });
            m("cut,copy,paste".split(","),
            function(a, c) {
                b.clickToolbar(c,
                function() {
                    b.focus();
                    try {
                        b.exec(c, null)
                    } catch(a) {
                        alert(b.lang(c + "Error"))
                    }
                })
            });
            b.clickToolbar("about",
            function() {
                var a = '<div style="margin:20px;"><div>KindEditor ' + Ca + '</div><div>Copyright &copy; <a href="http://www.kindsoft.net/" target="_blank">kindsoft.net</a> All rights reserved.</div></div>';
                b.createDialog({
                    name: "about",
                    width: 300,
                    title: b.lang("about"),
                    body: a
                })
            });
            b.plugin.getSelectedLink = function() {
                return b.cmd.commonAncestor("a")
            };
            b.plugin.getSelectedImage = function() {
                return Aa(b.edit.cmd.range,
                function(a) {
                    return ! /^ke-\w+$/i.test(a[0].className)
                })
            };
            b.plugin.getSelectedFlash = function() {
                return Aa(b.edit.cmd.range,
                function(a) {
                    return a[0].className == "ke-flash"
                })
            };
            b.plugin.getSelectedMedia = function() {
                return Aa(b.edit.cmd.range,
                function(a) {
                    return a[0].className == "ke-media" || a[0].className == "ke-rm"
                })
            };
            b.plugin.getSelectedAnchor = function() {
                return Aa(b.edit.cmd.range,
                function(a) {
                    return a[0].className == "ke-anchor"
                })
            };
            m("link,image,flash,media,anchor".split(","),
            function(a, c) {
                var d = c.charAt(0).toUpperCase() + c.substr(1);
                m("edit,delete".split(","),
                function(a, e) {
                    b.addContextmenu({
                        title: b.lang(e + d),
                        click: function() {
                            b.loadPlugin(c,
                            function() {
                                b.plugin[c][e]();
                                b.hideMenu()
                            })
                        },
                        cond: b.plugin["getSelected" + d],
                        width: 150,
                        iconClass: e == "edit" ? "ke-icon-" + c: j
                    })
                });
                b.addContextmenu({
                    title: "-"
                })
            });
            b.plugin.getSelectedTable = function() {
                return b.cmd.commonAncestor("table")
            };
            b.plugin.getSelectedRow = function() {
                return b.cmd.commonAncestor("tr")
            };
            b.plugin.getSelectedCell = function() {
                return b.cmd.commonAncestor("td")
            };
            m("prop,cellprop,colinsertleft,colinsertright,rowinsertabove,rowinsertbelow,rowmerge,colmerge,rowsplit,colsplit,coldelete,rowdelete,insert,delete".split(","),
            function(a, c) {
                var d = L(c, ["prop", "delete"]) < 0 ? b.plugin.getSelectedCell: b.plugin.getSelectedTable;
                b.addContextmenu({
                    title: b.lang("table" + c),
                    click: function() {
                        b.loadPlugin("table",
                        function() {
                            b.plugin.table[c]();
                            b.hideMenu()
                        })
                    },
                    cond: d,
                    width: 170,
                    iconClass: "ke-icon-table" + c
                })
            });
            b.addContextmenu({
                title: "-"
            });
            m("selectall,justifyleft,justifycenter,justifyright,justifyfull,insertorderedlist,insertunorderedlist,indent,outdent,subscript,superscript,hr,print,bold,italic,underline,strikethrough,removeformat,unlink".split(","),
            function(a, d) {
                c[d] && b.afterCreate(function() {
                    Ga(this.edit.doc, c[d],
                    function() {
                        b.cmd.selection();
                        b.clickToolbar(d)
                    })
                });
                b.clickToolbar(d,
                function() {
                    b.focus().exec(d, null)
                })
            });
            b.afterCreate(function() {
                function c() {
                    f.range.moveToBookmark(i);
                    f.select();
                    ba && (a("div." + j, k).each(function() {
                        a(this).after("<br />").remove(!0)
                    }), a("span.Apple-style-span", k).remove(!0), a("meta", k).remove());
                    var d = k[0].innerHTML;
                    k.remove();
                    d !== "" && (b.pasteType === 2 && (/schemas-microsoft-com|worddocument|mso-\w+/i.test(d) ? d = lb(d, b.filterMode ? b.htmlTags: a.options.htmlTags) : (d = Q(d, b.filterMode ? b.htmlTags: null), d = b.beforeSetHtml(d))), b.pasteType === 1 && (d = d.replace(/<br[^>]*>/ig, "\n"), d = d.replace(/<\/p><p[^>]*>/ig, "\n"), d = d.replace(/<[^>]+>/g, ""), d = d.replace(/&nbsp;/ig, " "), d = d.replace(/\n\s*\n/g, "\n"), d = d.replace(/ {2}/g, " &nbsp;"), b.newlineTag == "p" ? /\n/.test(d) && (d = d.replace(/^/, "<p>").replace(/$/, "</p>").replace(/\n/g, "</p><p>")) : d = d.replace(/\n/g, "<br />$&")), b.insertHtml(d, !0))
                }
                var d = b.edit.doc,
                f, i, k, j = "__kindeditor_paste__",
                l = !1;
                a(d.body).bind("paste",
                function(m) {
                    if (b.pasteType === 0) m.stop();
                    else if (!l) {
                        l = !0;
                        a("div." + j, d).remove();
                        f = b.cmd.selection();
                        i = f.range.createBookmark();
                        k = a('<div class="' + j + '"></div>', d).css({
                            position: "absolute",
                            width: "1px",
                            height: "1px",
                            overflow: "hidden",
                            left: "-1981px",
                            top: a(i.start).pos().y + "px",
                            "white-space": "nowrap"
                        });
                        a(d.body).append(k);
                        if (o) {
                            var p = f.range.get(!0);
                            p.moveToElementText(k[0]);
                            p.select();
                            p.execCommand("paste");
                            m.preventDefault()
                        } else f.range.selectNodeContents(k[0]),
                        f.select();
                        setTimeout(function() {
                            c();
                            l = !1
                        },
                        0)
                    }
                })
            });
            b.beforeGetHtml(function(a) {
                return a.replace(/(<(?:noscript|noscript\s[^>]*)>)([\s\S]*?)(<\/noscript>)/ig,
                function(a, b, c, d) {
                    return b + Ea(c).replace(/\s+/g, " ") + d
                }).replace(/<img[^>]*class="?ke-(flash|rm|media)"?[^>]*>/ig,
                function(a) {
                    var a = J(a),
                    b = ea(a.style || ""),
                    c = nb(a["data-ke-tag"]);
                    c.width = l(a.width, t(l(b.width, "")));
                    c.height = l(a.height, t(l(b.height, "")));
                    return Ia(c)
                }).replace(/<img[^>]*class="?ke-anchor"?[^>]*>/ig,
                function(a) {
                    a = J(a);
                    return '<a name="' + unescape(a["data-ke-name"]) + '"></a>'
                }).replace(/<div\s+[^>]*data-ke-script-attr="([^"]*)"[^>]*>([\s\S]*?)<\/div>/ig,
                function(a, b, c) {
                    return "<script" + unescape(b) + ">" + unescape(c) + "<\/script>"
                }).replace(/<div\s+[^>]*data-ke-noscript-attr="([^"]*)"[^>]*>([\s\S]*?)<\/div>/ig,
                function(a, b, c) {
                    return "<noscript" + unescape(b) + ">" + unescape(c) + "</noscript>"
                }).replace(/(<[^>]*)data-ke-src="([^"]*)"([^>]*>)/ig,
                function(a, b, c) {
                    a = a.replace(/(\s+(?:href|src)=")[^"]*(")/i, "$1" + c + "$2");
                    return a = a.replace(/\s+data-ke-src="[^"]*"/i, "")
                }).replace(/(<[^>]+\s)data-ke-(on\w+="[^"]*"[^>]*>)/ig,
                function(a, b, c) {
                    return b + c
                })
            });
            b.beforeSetHtml(function(a) {
                return a.replace(/<embed[^>]*type="([^"]+)"[^>]*>(?:<\/embed>)?/ig,
                function(a) {
                    a = J(a);
                    a.src = l(a.src, "");
                    a.width = l(a.width, 0);
                    a.height = l(a.height, 0);
                    return ob(b.themesPath + "common/blank.gif", a)
                }).replace(/<a[^>]*name="([^"]+)"[^>]*>(?:<\/a>)?/ig,
                function(a) {
                    var c = J(a);
                    if (c.href !== j) return a;
                    return '<img class="ke-anchor" src="' + b.themesPath + 'common/anchor.gif" data-ke-name="' + escape(c.name) + '" />'
                }).replace(/<script([^>]*)>([\s\S]*?)<\/script>/ig,
                function(a, b, c) {
                    return '<div class="ke-script" data-ke-script-attr="' + escape(b) + '">' + escape(c) + "</div>"
                }).replace(/<noscript([^>]*)>([\s\S]*?)<\/noscript>/ig,
                function(a, b, c) {
                    return '<div class="ke-noscript" data-ke-noscript-attr="' + escape(b) + '">' + escape(c) + "</div>"
                }).replace(/(<[^>]*)(href|src)="([^"]*)"([^>]*>)/ig,
                function(a, b, c, d, e) {
                    if (a.match(/\sdata-ke-src="[^"]*"/i)) return a;
                    return b + c + '="' + d + '" data-ke-src="' + d + '"' + e
                }).replace(/(<[^>]+\s)(on\w+="[^"]*"[^>]*>)/ig,
                function(a, b, c) {
                    return b + "data-ke-" + c
                }).replace(/<table[^>]*\s+border="0"[^>]*>/ig,
                function(a) {
                    if (a.indexOf("ke-zeroborder") >= 0) return a;
                    return Rb(a, "ke-zeroborder")
                })
            })
        })
    }
})(window);