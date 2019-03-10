/*! AdminLTE app.js
* ================
* Main JS application file for AdminLTE v2. This file
* should be included in all pages. It controls some layout
* options and implements exclusive AdminLTE plugins.
*
* @Author  Almsaeed Studio
* @Support <https://www.almsaeedstudio.com>
* @Email   <abdullah@almsaeedstudio.com>
* @version 2.4.2
* @repository git://github.com/almasaeed2010/AdminLTE.git
* @license MIT <http://opensource.org/licenses/MIT>
*/

// Make sure jQuery has been loaded
if (typeof jQuery === 'undefined') {
throw new Error('AdminLTE requires jQuery')
}

/* BoxRefresh()
 * =========
 * Adds AJAX content control to a box.
 *
 * @Usage: $('#my-box').boxRefresh(options)
 *         or add [data-widget="box-refresh"] to the box element
 *         Pass any option as data-option="value"
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.boxrefresh';

  var Default = {
    source         : '',
    params         : {},
    trigger        : '.refresh-btn',
    content        : '.box-body',
    loadInContent  : true,
    responseType   : '',
    overlayTemplate: '<div class="overlay"><div class="fa fa-refresh fa-spin"></div></div>',
    onLoadStart    : function () {
    },
    onLoadDone     : function (response) {
      return response;
    }
  };

  var Selector = {
    data: '[data-widget="box-refresh"]'
  };

  // BoxRefresh Class Definition
  // =========================
  var BoxRefresh = function (element, options) {
    this.element  = element;
    this.options  = options;
    this.$overlay = $(options.overlay);

    if (options.source === '') {
      throw new Error('Source url was not defined. Please specify a url in your BoxRefresh source option.');
    }

    this._setUpListeners();
    this.load();
  };

  BoxRefresh.prototype.load = function () {
    this._addOverlay();
    this.options.onLoadStart.call($(this));

    $.get(this.options.source, this.options.params, function (response) {
      if (this.options.loadInContent) {
        $(this.options.content).html(response);
      }
      this.options.onLoadDone.call($(this), response);
      this._removeOverlay();
    }.bind(this), this.options.responseType !== '' && this.options.responseType);
  };

  // Private

  BoxRefresh.prototype._setUpListeners = function () {
    $(this.element).on('click', Selector.trigger, function (event) {
      if (event) event.preventDefault();
      this.load();
    }.bind(this));
  };

  BoxRefresh.prototype._addOverlay = function () {
    $(this.element).append(this.$overlay);
  };

  BoxRefresh.prototype._removeOverlay = function () {
    $(this.element).remove(this.$overlay);
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option == 'object' && option);
        $this.data(DataKey, (data = new BoxRefresh($this, options)));
      }

      if (typeof data == 'string') {
        if (typeof data[option] == 'undefined') {
          throw new Error('No method named ' + option);
        }
        data[option]();
      }
    });
  }

  var old = $.fn.boxRefresh;

  $.fn.boxRefresh             = Plugin;
  $.fn.boxRefresh.Constructor = BoxRefresh;

  // No Conflict Mode
  // ================
  $.fn.boxRefresh.noConflict = function () {
    $.fn.boxRefresh = old;
    return this;
  };

  // BoxRefresh Data API
  // =================
  $(window).on('load', function () {
    $(Selector.data).each(function () {
      Plugin.call($(this));
    });
  });

}(jQuery);


/* BoxWidget()
 * ======
 * Adds box widget functions to boxes.
 *
 * @Usage: $('.my-box').boxWidget(options)
 *         This plugin auto activates on any element using the `.box` class
 *         Pass any option as data-option="value"
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.boxwidget';

  var Default = {
    animationSpeed : 500,
    collapseTrigger: '[data-widget="collapse"]',
    removeTrigger  : '[data-widget="remove"]',
    collapseIcon   : 'fa-minus',
    expandIcon     : 'fa-plus',
    removeIcon     : 'fa-times'
  };

  var Selector = {
    data     : '.box',
    collapsed: '.collapsed-box',
    header   : '.box-header',
    body     : '.box-body',
    footer   : '.box-footer',
    tools    : '.box-tools'
  };

  var ClassName = {
    collapsed: 'collapsed-box'
  };

  var Event = {
    collapsed: 'collapsed.boxwidget',
    expanded : 'expanded.boxwidget',
    removed  : 'removed.boxwidget'
  };

  // BoxWidget Class Definition
  // =====================
  var BoxWidget = function (element, options) {
    this.element = element;
    this.options = options;

    this._setUpListeners();
  };

  BoxWidget.prototype.toggle = function () {
    var isOpen = !$(this.element).is(Selector.collapsed);

    if (isOpen) {
      this.collapse();
    } else {
      this.expand();
    }
  };

  BoxWidget.prototype.expand = function () {
    var expandedEvent = $.Event(Event.expanded);
    var collapseIcon  = this.options.collapseIcon;
    var expandIcon    = this.options.expandIcon;

    $(this.element).removeClass(ClassName.collapsed);

    $(this.element)
      .children(Selector.header + ', ' + Selector.body + ', ' + Selector.footer)
      .children(Selector.tools)
      .find('.' + expandIcon)
      .removeClass(expandIcon)
      .addClass(collapseIcon);

    $(this.element).children(Selector.body + ', ' + Selector.footer)
      .slideDown(this.options.animationSpeed, function () {
        $(this.element).trigger(expandedEvent);
      }.bind(this));
  };

  BoxWidget.prototype.collapse = function () {
    var collapsedEvent = $.Event(Event.collapsed);
    var collapseIcon   = this.options.collapseIcon;
    var expandIcon     = this.options.expandIcon;

    $(this.element)
      .children(Selector.header + ', ' + Selector.body + ', ' + Selector.footer)
      .children(Selector.tools)
      .find('.' + collapseIcon)
      .removeClass(collapseIcon)
      .addClass(expandIcon);

    $(this.element).children(Selector.body + ', ' + Selector.footer)
      .slideUp(this.options.animationSpeed, function () {
        $(this.element).addClass(ClassName.collapsed);
        $(this.element).trigger(collapsedEvent);
      }.bind(this));
  };

  BoxWidget.prototype.remove = function () {
    var removedEvent = $.Event(Event.removed);

    $(this.element).slideUp(this.options.animationSpeed, function () {
      $(this.element).trigger(removedEvent);
      $(this.element).remove();
    }.bind(this));
  };

  // Private

  BoxWidget.prototype._setUpListeners = function () {
    var that = this;

    $(this.element).on('click', this.options.collapseTrigger, function (event) {
      if (event) event.preventDefault();
      that.toggle($(this));
      return false;
    });

    $(this.element).on('click', this.options.removeTrigger, function (event) {
      if (event) event.preventDefault();
      that.remove($(this));
      return false;
    });
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option == 'object' && option);
        $this.data(DataKey, (data = new BoxWidget($this, options)));
      }

      if (typeof option == 'string') {
        if (typeof data[option] == 'undefined') {
          throw new Error('No method named ' + option);
        }
        data[option]();
      }
    });
  }

  var old = $.fn.boxWidget;

  $.fn.boxWidget             = Plugin;
  $.fn.boxWidget.Constructor = BoxWidget;

  // No Conflict Mode
  // ================
  $.fn.boxWidget.noConflict = function () {
    $.fn.boxWidget = old;
    return this;
  };

  // BoxWidget Data API
  // ==================
  $(window).on('load', function () {
    $(Selector.data).each(function () {
      Plugin.call($(this));
    });
  });
}(jQuery);


/* ControlSidebar()
 * ===============
 * Toggles the state of the control sidebar
 *
 * @Usage: $('#control-sidebar-trigger').controlSidebar(options)
 *         or add [data-toggle="control-sidebar"] to the trigger
 *         Pass any option as data-option="value"
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.controlsidebar';

  var Default = {
    slide: true
  };

  var Selector = {
    sidebar: '.control-sidebar',
    data   : '[data-toggle="control-sidebar"]',
    open   : '.control-sidebar-open',
    bg     : '.control-sidebar-bg',
    wrapper: '.wrapper',
    content: '.content-wrapper',
    boxed  : '.layout-boxed'
  };

  var ClassName = {
    open : 'control-sidebar-open',
    fixed: 'fixed'
  };

  var Event = {
    collapsed: 'collapsed.controlsidebar',
    expanded : 'expanded.controlsidebar'
  };

  // ControlSidebar Class Definition
  // ===============================
  var ControlSidebar = function (element, options) {
    this.element         = element;
    this.options         = options;
    this.hasBindedResize = false;

    this.init();
  };

  ControlSidebar.prototype.init = function () {
    // Add click listener if the element hasn't been
    // initialized using the data API
    if (!$(this.element).is(Selector.data)) {
      $(this).on('click', this.toggle);
    }

    this.fix();
    $(window).resize(function () {
      this.fix();
    }.bind(this));
  };

  ControlSidebar.prototype.toggle = function (event) {
    if (event) event.preventDefault();

    this.fix();

    if (!$(Selector.sidebar).is(Selector.open) && !$('body').is(Selector.open)) {
      this.expand();
    } else {
      this.collapse();
    }
  };

  ControlSidebar.prototype.expand = function () {
    if (!this.options.slide) {
      $('body').addClass(ClassName.open);
    } else {
      $(Selector.sidebar).addClass(ClassName.open);
    }

    $(this.element).trigger($.Event(Event.expanded));
  };

  ControlSidebar.prototype.collapse = function () {
    $('body, ' + Selector.sidebar).removeClass(ClassName.open);
    $(this.element).trigger($.Event(Event.collapsed));
  };

  ControlSidebar.prototype.fix = function () {
    if ($('body').is(Selector.boxed)) {
      this._fixForBoxed($(Selector.bg));
    }
  };

  // Private

  ControlSidebar.prototype._fixForBoxed = function (bg) {
    bg.css({
      position: 'absolute',
      height  : $(Selector.wrapper).height()
    });
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option == 'object' && option);
        $this.data(DataKey, (data = new ControlSidebar($this, options)));
      }

      if (typeof option == 'string') data.toggle();
    });
  }

  var old = $.fn.controlSidebar;

  $.fn.controlSidebar             = Plugin;
  $.fn.controlSidebar.Constructor = ControlSidebar;

  // No Conflict Mode
  // ================
  $.fn.controlSidebar.noConflict = function () {
    $.fn.controlSidebar = old;
    return this;
  };

  // ControlSidebar Data API
  // =======================
  $(document).on('click', Selector.data, function (event) {
    if (event) event.preventDefault();
    Plugin.call($(this), 'toggle');
  });

}(jQuery);


/* DirectChat()
 * ===============
 * Toggles the state of the control sidebar
 *
 * @Usage: $('#my-chat-box').directChat()
 *         or add [data-widget="direct-chat"] to the trigger
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.directchat';

  var Selector = {
    data: '[data-widget="chat-pane-toggle"]',
    box : '.direct-chat'
  };

  var ClassName = {
    open: 'direct-chat-contacts-open'
  };

  // DirectChat Class Definition
  // ===========================
  var DirectChat = function (element) {
    this.element = element;
  };

  DirectChat.prototype.toggle = function ($trigger) {
    $trigger.parents(Selector.box).first().toggleClass(ClassName.open);
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        $this.data(DataKey, (data = new DirectChat($this)));
      }

      if (typeof option == 'string') data.toggle($this);
    });
  }

  var old = $.fn.directChat;

  $.fn.directChat             = Plugin;
  $.fn.directChat.Constructor = DirectChat;

  // No Conflict Mode
  // ================
  $.fn.directChat.noConflict = function () {
    $.fn.directChat = old;
    return this;
  };

  // DirectChat Data API
  // ===================
  $(document).on('click', Selector.data, function (event) {
    if (event) event.preventDefault();
    Plugin.call($(this), 'toggle');
  });

}(jQuery);


/* Layout()
 * ========
 * Implements AdminLTE layout.
 * Fixes the layout height in case min-height fails.
 *
 * @usage activated automatically upon window load.
 *        Configure any options by passing data-option="value"
 *        to the body tag.
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.layout';

  var Default = {
    slimscroll : true,
    resetHeight: true
  };

  var Selector = {
    wrapper       : '.wrapper',
    contentWrapper: '.content-wrapper',
    layoutBoxed   : '.layout-boxed',
    mainFooter    : '.main-footer',
    mainHeader    : '.main-header',
    sidebar       : '.sidebar',
    controlSidebar: '.control-sidebar',
    fixed         : '.fixed',
    sidebarMenu   : '.sidebar-menu',
    logo          : '.main-header .logo'
  };

  var ClassName = {
    fixed         : 'fixed',
    holdTransition: 'hold-transition'
  };

  var Layout = function (options) {
    this.options      = options;
    this.bindedResize = false;
    this.activate();
  };

  Layout.prototype.activate = function () {
    this.fix();
    this.fixSidebar();

    $('body').removeClass(ClassName.holdTransition);

    if (this.options.resetHeight) {
      $('body, html, ' + Selector.wrapper).css({
        'height'    : 'auto',
        'min-height': '100%'
      });
    }

    if (!this.bindedResize) {
      $(window).resize(function () {
        this.fix();
        this.fixSidebar();

        $(Selector.logo + ', ' + Selector.sidebar).one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
          this.fix();
          this.fixSidebar();
        }.bind(this));
      }.bind(this));

      this.bindedResize = true;
    }

    $(Selector.sidebarMenu).on('expanded.tree', function () {
      this.fix();
      this.fixSidebar();
    }.bind(this));

    $(Selector.sidebarMenu).on('collapsed.tree', function () {
      this.fix();
      this.fixSidebar();
    }.bind(this));
  };

  Layout.prototype.fix = function () {
    // Remove overflow from .wrapper if layout-boxed exists
    $(Selector.layoutBoxed + ' > ' + Selector.wrapper).css('overflow', 'hidden');

    // Get window height and the wrapper height
    var footerHeight  = $(Selector.mainFooter).outerHeight() || 0;
    var neg           = $(Selector.mainHeader).outerHeight() + footerHeight;
    var windowHeight  = $(window).height();
    var sidebarHeight = $(Selector.sidebar).height() || 0;

    // Set the min-height of the content and sidebar based on
    // the height of the document.
    if ($('body').hasClass(ClassName.fixed)) {
      $(Selector.contentWrapper).css('min-height', windowHeight - footerHeight);
    } else {
      var postSetHeight;

      if (windowHeight >= sidebarHeight) {
        $(Selector.contentWrapper).css('min-height', windowHeight - neg);
        postSetHeight = windowHeight - neg;
      } else {
        $(Selector.contentWrapper).css('min-height', sidebarHeight);
        postSetHeight = sidebarHeight;
      }

      // Fix for the control sidebar height
      var $controlSidebar = $(Selector.controlSidebar);
      if (typeof $controlSidebar !== 'undefined') {
        if ($controlSidebar.height() > postSetHeight)
          $(Selector.contentWrapper).css('min-height', $controlSidebar.height());
      }
    }
  };

  Layout.prototype.fixSidebar = function () {
    // Make sure the body tag has the .fixed class
    if (!$('body').hasClass(ClassName.fixed)) {
      if (typeof $.fn.slimScroll !== 'undefined') {
        $(Selector.sidebar).slimScroll({ destroy: true }).height('auto');
      }
      return;
    }

    // Enable slimscroll for fixed layout
    if (this.options.slimscroll) {
      if (typeof $.fn.slimScroll !== 'undefined') {
        // Destroy if it exists
        // $(Selector.sidebar).slimScroll({ destroy: true }).height('auto')

        // Add slimscroll
        $(Selector.sidebar).slimScroll({
          height: ($(window).height() - $(Selector.mainHeader).height()) + 'px'
        });
      }
    }
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option === 'object' && option);
        $this.data(DataKey, (data = new Layout(options)));
      }

      if (typeof option === 'string') {
        if (typeof data[option] === 'undefined') {
          throw new Error('No method named ' + option);
        }
        data[option]();
      }
    });
  }

  var old = $.fn.layout;

  $.fn.layout            = Plugin;
  $.fn.layout.Constuctor = Layout;

  // No conflict mode
  // ================
  $.fn.layout.noConflict = function () {
    $.fn.layout = old;
    return this;
  };

  // Layout DATA-API
  // ===============
  $(window).on('load', function () {
    Plugin.call($('body'));
  });
}(jQuery);


/* PushMenu()
 * ==========
 * Adds the push menu functionality to the sidebar.
 *
 * @usage: $('.btn').pushMenu(options)
 *          or add [data-toggle="push-menu"] to any button
 *          Pass any option as data-option="value"
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.pushmenu';

  var Default = {
    collapseScreenSize   : 767,
    expandOnHover        : false,
    expandTransitionDelay: 200
  };

  var Selector = {
    collapsed     : '.sidebar-collapse',
    open          : '.sidebar-open',
    mainSidebar   : '.main-sidebar',
    contentWrapper: '.content-wrapper',
    searchInput   : '.sidebar-form .form-control',
    button        : '[data-toggle="push-menu"]',
    mini          : '.sidebar-mini',
    expanded      : '.sidebar-expanded-on-hover',
    layoutFixed   : '.fixed'
  };

  var ClassName = {
    collapsed    : 'sidebar-collapse',
    open         : 'sidebar-open',
    mini         : 'sidebar-mini',
    expanded     : 'sidebar-expanded-on-hover',
    expandFeature: 'sidebar-mini-expand-feature',
    layoutFixed  : 'fixed'
  };

  var Event = {
    expanded : 'expanded.pushMenu',
    collapsed: 'collapsed.pushMenu'
  };

  // PushMenu Class Definition
  // =========================
  var PushMenu = function (options) {
    this.options = options;
    this.init();
  };

  PushMenu.prototype.init = function () {
    if (this.options.expandOnHover
      || ($('body').is(Selector.mini + Selector.layoutFixed))) {
      this.expandOnHover();
      $('body').addClass(ClassName.expandFeature);
    }

    $(Selector.contentWrapper).click(function () {
      // Enable hide menu when clicking on the content-wrapper on small screens
      if ($(window).width() <= this.options.collapseScreenSize && $('body').hasClass(ClassName.open)) {
        this.close();
      }
    }.bind(this));

    // __Fix for android devices
    $(Selector.searchInput).click(function (e) {
      e.stopPropagation();
    });
  };

  PushMenu.prototype.toggle = function () {
    var windowWidth = $(window).width();
    var isOpen      = !$('body').hasClass(ClassName.collapsed);

    if (windowWidth <= this.options.collapseScreenSize) {
      isOpen = $('body').hasClass(ClassName.open);
    }

    if (!isOpen) {
      this.open();
    } else {
      this.close();
    }
  };

  PushMenu.prototype.open = function () {
    var windowWidth = $(window).width();

    if (windowWidth > this.options.collapseScreenSize) {
      $('body').removeClass(ClassName.collapsed)
        .trigger($.Event(Event.expanded));
    }
    else {
      $('body').addClass(ClassName.open)
        .trigger($.Event(Event.expanded));
    }
  };

  PushMenu.prototype.close = function () {
    var windowWidth = $(window).width();
    if (windowWidth > this.options.collapseScreenSize) {
      $('body').addClass(ClassName.collapsed)
        .trigger($.Event(Event.collapsed));
    } else {
      $('body').removeClass(ClassName.open + ' ' + ClassName.collapsed)
        .trigger($.Event(Event.collapsed));
    }
  };

  PushMenu.prototype.expandOnHover = function () {
    $(Selector.mainSidebar).hover(function () {
      if ($('body').is(Selector.mini + Selector.collapsed)
        && $(window).width() > this.options.collapseScreenSize) {
        this.expand();
      }
    }.bind(this), function () {
      if ($('body').is(Selector.expanded)) {
        this.collapse();
      }
    }.bind(this));
  };

  PushMenu.prototype.expand = function () {
    setTimeout(function () {
      $('body').removeClass(ClassName.collapsed)
        .addClass(ClassName.expanded);
    }, this.options.expandTransitionDelay);
  };

  PushMenu.prototype.collapse = function () {
    setTimeout(function () {
      $('body').removeClass(ClassName.expanded)
        .addClass(ClassName.collapsed);
    }, this.options.expandTransitionDelay);
  };

  // PushMenu Plugin Definition
  // ==========================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option == 'object' && option);
        $this.data(DataKey, (data = new PushMenu(options)));
      }

      if (option === 'toggle') data.toggle();
    });
  }

  var old = $.fn.pushMenu;

  $.fn.pushMenu             = Plugin;
  $.fn.pushMenu.Constructor = PushMenu;

  // No Conflict Mode
  // ================
  $.fn.pushMenu.noConflict = function () {
    $.fn.pushMenu = old;
    return this;
  };

  // Data API
  // ========
  $(document).on('click', Selector.button, function (e) {
    e.preventDefault();
    Plugin.call($(this), 'toggle');
  });
  $(window).on('load', function () {
    Plugin.call($(Selector.button));
  });
}(jQuery);


/* TodoList()
 * =========
 * Converts a list into a todoList.
 *
 * @Usage: $('.my-list').todoList(options)
 *         or add [data-widget="todo-list"] to the ul element
 *         Pass any option as data-option="value"
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.todolist';

  var Default = {
    onCheck  : function (item) {
      return item;
    },
    onUnCheck: function (item) {
      return item;
    }
  };

  var Selector = {
    data: '[data-widget="todo-list"]'
  };

  var ClassName = {
    done: 'done'
  };

  // TodoList Class Definition
  // =========================
  var TodoList = function (element, options) {
    this.element = element;
    this.options = options;

    this._setUpListeners();
  };

  TodoList.prototype.toggle = function (item) {
    item.parents(Selector.li).first().toggleClass(ClassName.done);
    if (!item.prop('checked')) {
      this.unCheck(item);
      return;
    }

    this.check(item);
  };

  TodoList.prototype.check = function (item) {
    this.options.onCheck.call(item);
  };

  TodoList.prototype.unCheck = function (item) {
    this.options.onUnCheck.call(item);
  };

  // Private

  TodoList.prototype._setUpListeners = function () {
    var that = this;
    $(this.element).on('change ifChanged', 'input:checkbox', function () {
      that.toggle($(this));
    });
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option == 'object' && option);
        $this.data(DataKey, (data = new TodoList($this, options)));
      }

      if (typeof data == 'string') {
        if (typeof data[option] == 'undefined') {
          throw new Error('No method named ' + option);
        }
        data[option]();
      }
    });
  }

  var old = $.fn.todoList;

  $.fn.todoList             = Plugin;
  $.fn.todoList.Constructor = TodoList;

  // No Conflict Mode
  // ================
  $.fn.todoList.noConflict = function () {
    $.fn.todoList = old;
    return this;
  };

  // TodoList Data API
  // =================
  $(window).on('load', function () {
    $(Selector.data).each(function () {
      Plugin.call($(this));
    });
  });

}(jQuery);


/* Tree()
 * ======
 * Converts a nested list into a multilevel
 * tree view menu.
 *
 * @Usage: $('.my-menu').tree(options)
 *         or add [data-widget="tree"] to the ul element
 *         Pass any option as data-option="value"
 */
+function ($) {
  'use strict';

  var DataKey = 'lte.tree';

  var Default = {
    animationSpeed: 500,
    accordion     : true,
    followLink    : false,
    trigger       : '.treeview a'
  };

  var Selector = {
    tree        : '.tree',
    treeview    : '.treeview',
    treeviewMenu: '.treeview-menu',
    open        : '.menu-open, .active',
    li          : 'li',
    data        : '[data-widget="tree"]',
    active      : '.active'
  };

  var ClassName = {
    open: 'menu-open',
    tree: 'tree'
  };

  var Event = {
    collapsed: 'collapsed.tree',
    expanded : 'expanded.tree'
  };

  // Tree Class Definition
  // =====================
  var Tree = function (element, options) {
    this.element = element;
    this.options = options;

    $(this.element).addClass(ClassName.tree);

    $(Selector.treeview + Selector.active, this.element).addClass(ClassName.open);

    this._setUpListeners();
  };

  Tree.prototype.toggle = function (link, event) {
    var treeviewMenu = link.next(Selector.treeviewMenu);
    var parentLi     = link.parent();
    var isOpen       = parentLi.hasClass(ClassName.open);

    if (!parentLi.is(Selector.treeview)) {
      return;
    }

    if (!this.options.followLink || link.attr('href') === '#') {
      event.preventDefault();
    }

    if (isOpen) {
      this.collapse(treeviewMenu, parentLi);
    } else {
      this.expand(treeviewMenu, parentLi);
    }
  };

  Tree.prototype.expand = function (tree, parent) {
    var expandedEvent = $.Event(Event.expanded);

    if (this.options.accordion) {
      var openMenuLi = parent.siblings(Selector.open);
      var openTree   = openMenuLi.children(Selector.treeviewMenu);
      this.collapse(openTree, openMenuLi);
    }

    parent.addClass(ClassName.open);
    tree.slideDown(this.options.animationSpeed, function () {
      $(this.element).trigger(expandedEvent);
    }.bind(this));
  };

  Tree.prototype.collapse = function (tree, parentLi) {
    var collapsedEvent = $.Event(Event.collapsed);

    tree.find(Selector.open).removeClass(ClassName.open);
    parentLi.removeClass(ClassName.open);
    tree.slideUp(this.options.animationSpeed, function () {
      tree.find(Selector.open + ' > ' + Selector.treeview).slideUp();
      $(this.element).trigger(collapsedEvent);
    }.bind(this));
  };

  // Private
  
  Tree.prototype._setUpListeners = function () {
    var that = this;

    $(this.element).on('click', this.options.trigger, function (event) {
      that.toggle($(this), event);
    });
  };

  // Plugin Definition
  // =================
  function Plugin(option) {
    return this.each(function () {
      var $this = $(this);
      var data  = $this.data(DataKey);

      if (!data) {
        var options = $.extend({}, Default, $this.data(), typeof option == 'object' && option);
        $this.data(DataKey, new Tree($this, options));
      }
    });
  }

  var old = $.fn.tree;

  $.fn.tree             = Plugin;
  $.fn.tree.Constructor = Tree;

  // No Conflict Mode
  // ================
  $.fn.tree.noConflict = function () {
    $.fn.tree = old;
    return this;
  };

  // Tree Data API
  // =============
  $(window).on('load', function () {
    $(Selector.data).each(function () {
      Plugin.call($(this));
    });
  });

}(jQuery);




/*
PNotify 3.2.0 sciactive.com/pnotify/
(C) 2015 Hunter Perrin; Google, Inc.
license Apache-2.0
*/
!function (t, i) { "function" == typeof define && define.amd ? define("pnotify", ["jquery"], function (s) { return i(s, t) }) : "object" == typeof exports && "undefined" != typeof module ? module.exports = i(require("jquery"), global || t) : t.PNotify = i(t.jQuery, t) }("undefined" != typeof window ? window : this, function (t, i) { var s = function (i) { var e, o, n = { dir1: "down", dir2: "left", push: "bottom", spacing1: 36, spacing2: 36, context: t("body"), modal: !1 }, a = t(i), r = function () { o = t("body"), c.prototype.options.stack.context = o, a = t(i), a.bind("resize", function () { e && clearTimeout(e), e = setTimeout(function () { c.positionAll(!0) }, 10) }) }, h = function (i) { var s = t("<div />", { class: "ui-pnotify-modal-overlay" }); return s.prependTo(i.context), i.overlay_close && s.click(function () { c.removeStack(i) }), s }, c = function (t) { this.state = "initializing", this.timer = null, this.animTimer = null, this.styles = null, this.elem = null, this.container = null, this.title_container = null, this.text_container = null, this.animating = !1, this.timerHide = !1, this.parseOptions(t), this.init() }; return t.extend(c.prototype, { version: "3.2.0", options: { title: !1, title_escape: !1, text: !1, text_escape: !1, styling: "brighttheme", addclass: "", cornerclass: "", auto_display: !0, width: "300px", min_height: "16px", type: "notice", icon: !0, animation: "fade", animate_speed: "normal", shadow: !0, hide: !0, delay: 8e3, mouse_reset: !0, remove: !0, insert_brs: !0, destroy: !0, stack: n }, modules: {}, runModules: function (t, i) { var s; for (var e in this.modules) s = "object" == typeof i && e in i ? i[e] : i, "function" == typeof this.modules[e][t] && (this.modules[e].notice = this, this.modules[e].options = "object" == typeof this.options[e] ? this.options[e] : {}, this.modules[e][t](this, "object" == typeof this.options[e] ? this.options[e] : {}, s)) }, init: function () { var i = this; return this.modules = {}, t.extend(!0, this.modules, c.prototype.modules), "object" == typeof this.options.styling ? this.styles = this.options.styling : this.styles = c.styling[this.options.styling], this.elem = t("<div />", { class: "ui-pnotify " + this.options.addclass, css: { display: "none" }, "aria-live": "assertive", "aria-role": "alertdialog", mouseenter: function (t) { if (i.options.mouse_reset && "out" === i.animating) { if (!i.timerHide) return; i.cancelRemove() } i.options.hide && i.options.mouse_reset && i.cancelRemove() }, mouseleave: function (t) { i.options.hide && i.options.mouse_reset && "out" !== i.animating && i.queueRemove(), c.positionAll() } }), "fade" === this.options.animation && this.elem.addClass("ui-pnotify-fade-" + this.options.animate_speed), this.container = t("<div />", { class: this.styles.container + " ui-pnotify-container " + ("error" === this.options.type ? this.styles.error : "info" === this.options.type ? this.styles.info : "success" === this.options.type ? this.styles.success : this.styles.notice), role: "alert" }).appendTo(this.elem), "" !== this.options.cornerclass && this.container.removeClass("ui-corner-all").addClass(this.options.cornerclass), this.options.shadow && this.container.addClass("ui-pnotify-shadow"), !1 !== this.options.icon && t("<div />", { class: "ui-pnotify-icon" }).append(t("<span />", { class: !0 === this.options.icon ? "error" === this.options.type ? this.styles.error_icon : "info" === this.options.type ? this.styles.info_icon : "success" === this.options.type ? this.styles.success_icon : this.styles.notice_icon : this.options.icon })).prependTo(this.container), this.title_container = t("<h4 />", { class: "ui-pnotify-title" }).appendTo(this.container), !1 === this.options.title ? this.title_container.hide() : this.options.title_escape ? this.title_container.text(this.options.title) : this.title_container.html(this.options.title), this.text_container = t("<div />", { class: "ui-pnotify-text", "aria-role": "alert" }).appendTo(this.container), !1 === this.options.text ? this.text_container.hide() : this.options.text_escape ? this.text_container.text(this.options.text) : this.text_container.html(this.options.insert_brs ? String(this.options.text).replace(/\n/g, "<br />") : this.options.text), "string" == typeof this.options.width && this.elem.css("width", this.options.width), "string" == typeof this.options.min_height && this.container.css("min-height", this.options.min_height), "top" === this.options.stack.push ? c.notices = t.merge([this], c.notices) : c.notices = t.merge(c.notices, [this]), "top" === this.options.stack.push && this.queuePosition(!1, 1), this.options.stack.animation = !1, this.runModules("init"), this.state = "closed", this.options.auto_display && this.open(), this }, update: function (i) { var s = this.options; return this.parseOptions(s, i), this.elem.removeClass("ui-pnotify-fade-slow ui-pnotify-fade-normal ui-pnotify-fade-fast"), "fade" === this.options.animation && this.elem.addClass("ui-pnotify-fade-" + this.options.animate_speed), this.options.cornerclass !== s.cornerclass && this.container.removeClass("ui-corner-all " + s.cornerclass).addClass(this.options.cornerclass), this.options.shadow !== s.shadow && (this.options.shadow ? this.container.addClass("ui-pnotify-shadow") : this.container.removeClass("ui-pnotify-shadow")), !1 === this.options.addclass ? this.elem.removeClass(s.addclass) : this.options.addclass !== s.addclass && this.elem.removeClass(s.addclass).addClass(this.options.addclass), !1 === this.options.title ? this.title_container.slideUp("fast") : this.options.title !== s.title && (this.options.title_escape ? this.title_container.text(this.options.title) : this.title_container.html(this.options.title), !1 === s.title && this.title_container.slideDown(200)), !1 === this.options.text ? this.text_container.slideUp("fast") : this.options.text !== s.text && (this.options.text_escape ? this.text_container.text(this.options.text) : this.text_container.html(this.options.insert_brs ? String(this.options.text).replace(/\n/g, "<br />") : this.options.text), !1 === s.text && this.text_container.slideDown(200)), this.options.type !== s.type && this.container.removeClass(this.styles.error + " " + this.styles.notice + " " + this.styles.success + " " + this.styles.info).addClass("error" === this.options.type ? this.styles.error : "info" === this.options.type ? this.styles.info : "success" === this.options.type ? this.styles.success : this.styles.notice), (this.options.icon !== s.icon || !0 === this.options.icon && this.options.type !== s.type) && (this.container.find("div.ui-pnotify-icon").remove(), !1 !== this.options.icon && t("<div />", { class: "ui-pnotify-icon" }).append(t("<span />", { class: !0 === this.options.icon ? "error" === this.options.type ? this.styles.error_icon : "info" === this.options.type ? this.styles.info_icon : "success" === this.options.type ? this.styles.success_icon : this.styles.notice_icon : this.options.icon })).prependTo(this.container)), this.options.width !== s.width && this.elem.animate({ width: this.options.width }), this.options.min_height !== s.min_height && this.container.animate({ minHeight: this.options.min_height }), this.options.hide ? s.hide || this.queueRemove() : this.cancelRemove(), this.queuePosition(!0), this.runModules("update", s), this }, open: function () { this.state = "opening", this.runModules("beforeOpen"); var t = this; return this.elem.parent().length || this.elem.appendTo(this.options.stack.context ? this.options.stack.context : o), "top" !== this.options.stack.push && this.position(!0), this.animateIn(function () { t.queuePosition(!0), t.options.hide && t.queueRemove(), t.state = "open", t.runModules("afterOpen") }), this }, remove: function (s) { this.state = "closing", this.timerHide = !!s, this.runModules("beforeClose"); var e = this; return this.timer && (i.clearTimeout(this.timer), this.timer = null), this.animateOut(function () { if (e.state = "closed", e.runModules("afterClose"), e.queuePosition(!0), e.options.remove && e.elem.detach(), e.runModules("beforeDestroy"), e.options.destroy && null !== c.notices) { var i = t.inArray(e, c.notices); -1 !== i && c.notices.splice(i, 1) } e.runModules("afterDestroy") }), this }, get: function () { return this.elem }, parseOptions: function (i, s) { this.options = t.extend(!0, {}, c.prototype.options), this.options.stack = c.prototype.options.stack; for (var e, o = [i, s], n = 0; n < o.length && void 0 !== (e = o[n]); n++) if ("object" != typeof e) this.options.text = e; else for (var a in e) this.modules[a] ? t.extend(!0, this.options[a], e[a]) : this.options[a] = e[a] }, animateIn: function (t) { this.animating = "in"; var i = this, s = function () { i.animTimer && clearTimeout(i.animTimer), "in" === i.animating && (i.elem.is(":visible") ? (t && t.call(), i.animating = !1) : i.animTimer = setTimeout(s, 40)) }; "fade" === this.options.animation ? (this.elem.one("webkitTransitionEnd mozTransitionEnd MSTransitionEnd oTransitionEnd transitionend", s).addClass("ui-pnotify-in"), this.elem.css("opacity"), this.elem.addClass("ui-pnotify-fade-in"), this.animTimer = setTimeout(s, 650)) : (this.elem.addClass("ui-pnotify-in"), s()) }, animateOut: function (i) { this.animating = "out"; var s = this, e = function () { if (s.animTimer && clearTimeout(s.animTimer), "out" === s.animating) if ("0" != s.elem.css("opacity") && s.elem.is(":visible")) s.animTimer = setTimeout(e, 40); else { if (s.elem.removeClass("ui-pnotify-in"), s.options.stack.overlay) { var o = !1; t.each(c.notices, function (t, i) { i != s && i.options.stack === s.options.stack && "closed" != i.state && (o = !0) }), o || s.options.stack.overlay.hide() } i && i.call(), s.animating = !1 } }; "fade" === this.options.animation ? (this.elem.one("webkitTransitionEnd mozTransitionEnd MSTransitionEnd oTransitionEnd transitionend", e).removeClass("ui-pnotify-fade-in"), this.animTimer = setTimeout(e, 650)) : (this.elem.removeClass("ui-pnotify-in"), e()) }, position: function (t) { var i = this.options.stack, s = this.elem; if (void 0 === i.context && (i.context = o), i) { "number" != typeof i.nextpos1 && (i.nextpos1 = i.firstpos1), "number" != typeof i.nextpos2 && (i.nextpos2 = i.firstpos2), "number" != typeof i.addpos2 && (i.addpos2 = 0); var e = !s.hasClass("ui-pnotify-in"); if (!e || t) { i.modal && (i.overlay ? i.overlay.show() : i.overlay = h(i)), s.addClass("ui-pnotify-move"); var n, r, c; switch (i.dir1) { case "down": c = "top"; break; case "up": c = "bottom"; break; case "left": c = "right"; break; case "right": c = "left" } n = parseInt(s.css(c).replace(/(?:\..*|[^0-9.])/g, "")), isNaN(n) && (n = 0), void 0 !== i.firstpos1 || e || (i.firstpos1 = n, i.nextpos1 = i.firstpos1); var p; switch (i.dir2) { case "down": p = "top"; break; case "up": p = "bottom"; break; case "left": p = "right"; break; case "right": p = "left" } switch (r = parseInt(s.css(p).replace(/(?:\..*|[^0-9.])/g, "")), isNaN(r) && (r = 0), void 0 !== i.firstpos2 || e || (i.firstpos2 = r, i.nextpos2 = i.firstpos2), ("down" === i.dir1 && i.nextpos1 + s.height() > (i.context.is(o) ? a.height() : i.context.prop("scrollHeight")) || "up" === i.dir1 && i.nextpos1 + s.height() > (i.context.is(o) ? a.height() : i.context.prop("scrollHeight")) || "left" === i.dir1 && i.nextpos1 + s.width() > (i.context.is(o) ? a.width() : i.context.prop("scrollWidth")) || "right" === i.dir1 && i.nextpos1 + s.width() > (i.context.is(o) ? a.width() : i.context.prop("scrollWidth"))) && (i.nextpos1 = i.firstpos1, i.nextpos2 += i.addpos2 + (void 0 === i.spacing2 ? 25 : i.spacing2), i.addpos2 = 0), "number" == typeof i.nextpos2 && (i.animation ? s.css(p, i.nextpos2 + "px") : (s.removeClass("ui-pnotify-move"), s.css(p, i.nextpos2 + "px"), s.css(p), s.addClass("ui-pnotify-move"))), i.dir2) { case "down": case "up": s.outerHeight(!0) > i.addpos2 && (i.addpos2 = s.height()); break; case "left": case "right": s.outerWidth(!0) > i.addpos2 && (i.addpos2 = s.width()) } switch ("number" == typeof i.nextpos1 && (i.animation ? s.css(c, i.nextpos1 + "px") : (s.removeClass("ui-pnotify-move"), s.css(c, i.nextpos1 + "px"), s.css(c), s.addClass("ui-pnotify-move"))), i.dir1) { case "down": case "up": i.nextpos1 += s.height() + (void 0 === i.spacing1 ? 25 : i.spacing1); break; case "left": case "right": i.nextpos1 += s.width() + (void 0 === i.spacing1 ? 25 : i.spacing1) } } return this } }, queuePosition: function (t, i) { return e && clearTimeout(e), i || (i = 10), e = setTimeout(function () { c.positionAll(t) }, i), this }, cancelRemove: function () { return this.timer && i.clearTimeout(this.timer), this.animTimer && i.clearTimeout(this.animTimer), "closing" === this.state && (this.state = "open", this.animating = !1, this.elem.addClass("ui-pnotify-in"), "fade" === this.options.animation && this.elem.addClass("ui-pnotify-fade-in")), this }, queueRemove: function () { var t = this; return this.cancelRemove(), this.timer = i.setTimeout(function () { t.remove(!0) }, isNaN(this.options.delay) ? 0 : this.options.delay), this } }), t.extend(c, { notices: [], reload: s, removeAll: function () { t.each(c.notices, function (t, i) { i.remove && i.remove(!1) }) }, removeStack: function (i) { t.each(c.notices, function (t, s) { s.remove && s.options.stack === i && s.remove(!1) }) }, positionAll: function (i) { if (e && clearTimeout(e), e = null, c.notices && c.notices.length) t.each(c.notices, function (t, s) { var e = s.options.stack; e && (e.overlay && e.overlay.hide(), e.nextpos1 = e.firstpos1, e.nextpos2 = e.firstpos2, e.addpos2 = 0, e.animation = i) }), t.each(c.notices, function (t, i) { i.position() }); else { var s = c.prototype.options.stack; s && (delete s.nextpos1, delete s.nextpos2) } }, styling: { brighttheme: { container: "brighttheme", notice: "brighttheme-notice", notice_icon: "brighttheme-icon-notice", info: "brighttheme-info", info_icon: "brighttheme-icon-info", success: "brighttheme-success", success_icon: "brighttheme-icon-success", error: "brighttheme-error", error_icon: "brighttheme-icon-error" }, bootstrap3: { container: "alert", notice: "alert-warning", notice_icon: "glyphicon glyphicon-exclamation-sign", info: "alert-info", info_icon: "glyphicon glyphicon-info-sign", success: "alert-success", success_icon: "glyphicon glyphicon-ok-sign", error: "alert-danger", error_icon: "glyphicon glyphicon-warning-sign" } } }), c.styling.fontawesome = t.extend({}, c.styling.bootstrap3), t.extend(c.styling.fontawesome, { notice_icon: "fa fa-exclamation-circle", info_icon: "fa fa-info", success_icon: "fa fa-check", error_icon: "fa fa-warning" }), i.document.body ? r() : t(r), c }; return s(i) });
//# sourceMappingURL=pnotify.js.map
// Buttons
!function (o, s) { "function" == typeof define && define.amd ? define("pnotify.buttons", ["jquery", "pnotify"], s) : "object" == typeof exports && "undefined" != typeof module ? module.exports = s(require("jquery"), require("./pnotify")) : s(o.jQuery, o.PNotify) }("undefined" != typeof window ? window : this, function (o, s) { return s.prototype.options.buttons = { closer: !0, closer_hover: !0, sticker: !0, sticker_hover: !0, show_on_nonblock: !1, labels: { close: "Close", stick: "Stick", unstick: "Unstick" }, classes: { closer: null, pin_up: null, pin_down: null } }, s.prototype.modules.buttons = { init: function (s, i) { var n = this; s.elem.on({ mouseenter: function (o) { !n.options.sticker || s.options.nonblock && s.options.nonblock.nonblock && !n.options.show_on_nonblock || n.sticker.trigger("pnotify:buttons:toggleStick").css("visibility", "visible"), !n.options.closer || s.options.nonblock && s.options.nonblock.nonblock && !n.options.show_on_nonblock || n.closer.css("visibility", "visible") }, mouseleave: function (o) { n.options.sticker_hover && n.sticker.css("visibility", "hidden"), n.options.closer_hover && n.closer.css("visibility", "hidden") } }), this.sticker = o("<div />", { class: "ui-pnotify-sticker", "aria-role": "button", "aria-pressed": s.options.hide ? "false" : "true", tabindex: "0", title: s.options.hide ? i.labels.stick : i.labels.unstick, css: { cursor: "pointer", visibility: i.sticker_hover ? "hidden" : "visible" }, click: function () { s.options.hide = !s.options.hide, s.options.hide ? s.queueRemove() : s.cancelRemove(), o(this).trigger("pnotify:buttons:toggleStick") } }).bind("pnotify:buttons:toggleStick", function () { var i = null === n.options.classes.pin_up ? s.styles.pin_up : n.options.classes.pin_up, e = null === n.options.classes.pin_down ? s.styles.pin_down : n.options.classes.pin_down; o(this).attr("title", s.options.hide ? n.options.labels.stick : n.options.labels.unstick).children().attr("class", "").addClass(s.options.hide ? i : e).attr("aria-pressed", s.options.hide ? "false" : "true") }).append("<span />").trigger("pnotify:buttons:toggleStick").prependTo(s.container), (!i.sticker || s.options.nonblock && s.options.nonblock.nonblock && !i.show_on_nonblock) && this.sticker.css("display", "none"), this.closer = o("<div />", { class: "ui-pnotify-closer", "aria-role": "button", tabindex: "0", title: i.labels.close, css: { cursor: "pointer", visibility: i.closer_hover ? "hidden" : "visible" }, click: function () { s.remove(!1), n.sticker.css("visibility", "hidden"), n.closer.css("visibility", "hidden") } }).append(o("<span />", { class: null === i.classes.closer ? s.styles.closer : i.classes.closer })).prependTo(s.container), (!i.closer || s.options.nonblock && s.options.nonblock.nonblock && !i.show_on_nonblock) && this.closer.css("display", "none") }, update: function (o, s) { !s.closer || o.options.nonblock && o.options.nonblock.nonblock && !s.show_on_nonblock ? this.closer.css("display", "none") : s.closer && this.closer.css("display", "block"), !s.sticker || o.options.nonblock && o.options.nonblock.nonblock && !s.show_on_nonblock ? this.sticker.css("display", "none") : s.sticker && this.sticker.css("display", "block"), this.sticker.trigger("pnotify:buttons:toggleStick"), this.closer.find("span").attr("class", "").addClass(null === s.classes.closer ? o.styles.closer : s.classes.closer), s.sticker_hover ? this.sticker.css("visibility", "hidden") : o.options.nonblock && o.options.nonblock.nonblock && !s.show_on_nonblock || this.sticker.css("visibility", "visible"), s.closer_hover ? this.closer.css("visibility", "hidden") : o.options.nonblock && o.options.nonblock.nonblock && !s.show_on_nonblock || this.closer.css("visibility", "visible") } }, o.extend(s.styling.brighttheme, { closer: "brighttheme-icon-closer", pin_up: "brighttheme-icon-sticker", pin_down: "brighttheme-icon-sticker brighttheme-icon-stuck" }), o.extend(s.styling.bootstrap3, { closer: "glyphicon glyphicon-remove", pin_up: "glyphicon glyphicon-pause", pin_down: "glyphicon glyphicon-play" }), o.extend(s.styling.fontawesome, { closer: "fa fa-times", pin_up: "fa fa-pause", pin_down: "fa fa-play" }), s });
//# sourceMappingURL=pnotify.buttons.js.map
// Desktop
!function (i, t) { "function" == typeof define && define.amd ? define("pnotify.desktop", ["jquery", "pnotify"], t) : "object" == typeof exports && "undefined" != typeof module ? module.exports = t(require("jquery"), require("./pnotify")) : t(i.jQuery, i.PNotify) }("undefined" != typeof window ? window : this, function (i, t) { var o, n = function (i, t) { return (n = "Notification" in window ? function (i, t) { return new Notification(i, t) } : "mozNotification" in navigator ? function (i, t) { return navigator.mozNotification.createNotification(i, t.body, t.icon).show() } : "webkitNotifications" in window ? function (i, t) { return window.webkitNotifications.createNotification(t.icon, i, t.body) } : function (i, t) { return null })(i, t) }; return t.prototype.options.desktop = { desktop: !1, fallback: !0, icon: null, tag: null, title: null, text: null }, t.prototype.modules.desktop = { genNotice: function (i, t) { null === t.icon ? this.icon = "http://sciactive.com/pnotify/includes/desktop/" + i.options.type + ".png" : !1 === t.icon ? this.icon = null : this.icon = t.icon, null !== this.tag && null === t.tag || (this.tag = null === t.tag ? "PNotify-" + Math.round(1e6 * Math.random()) : t.tag), i.desktop = n(t.title || i.options.title, { icon: this.icon, body: t.text || i.options.text, tag: this.tag }), !("close" in i.desktop) && "cancel" in i.desktop && (i.desktop.close = function () { i.desktop.cancel() }), i.desktop.onclick = function () { i.elem.trigger("click") }, i.desktop.onclose = function () { "closing" !== i.state && "closed" !== i.state && i.remove() } }, init: function (i, n) { if (n.desktop) { if (0 !== (o = t.desktop.checkPermission())) return void (n.fallback || (i.options.auto_display = !1)); this.genNotice(i, n) } }, update: function (i, t, n) { 0 !== o && t.fallback || !t.desktop || this.genNotice(i, t) }, beforeOpen: function (i, t) { 0 !== o && t.fallback || !t.desktop || i.elem.css({ left: "-10000px" }).removeClass("ui-pnotify-in") }, afterOpen: function (i, t) { 0 !== o && t.fallback || !t.desktop || (i.elem.css({ left: "-10000px" }).removeClass("ui-pnotify-in"), "show" in i.desktop && i.desktop.show()) }, beforeClose: function (i, t) { 0 !== o && t.fallback || !t.desktop || i.elem.css({ left: "-10000px" }).removeClass("ui-pnotify-in") }, afterClose: function (i, t) { 0 !== o && t.fallback || !t.desktop || (i.elem.css({ left: "-10000px" }).removeClass("ui-pnotify-in"), "close" in i.desktop && i.desktop.close()) } }, t.desktop = { permission: function () { "undefined" != typeof Notification && "requestPermission" in Notification ? Notification.requestPermission() : "webkitNotifications" in window && window.webkitNotifications.requestPermission() }, checkPermission: function () { return "undefined" != typeof Notification && "permission" in Notification ? "granted" === Notification.permission ? 0 : 1 : "webkitNotifications" in window && 0 == window.webkitNotifications.checkPermission() ? 0 : 1 } }, o = t.desktop.checkPermission(), t });
//# sourceMappingURL=pnotify.desktop.js.map
