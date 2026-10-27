module.exports = {
  title: 'Movilidad Urbana (ensayo)', url: 'https://example.invalid', baseUrl: '/',
  onBrokenLinks: 'throw',
  markdown: { mermaid: true, hooks: { onBrokenMarkdownLinks: 'throw' } }, themes: ['@docusaurus/theme-mermaid'],
  presets: [['classic', { docs: { routeBasePath: '/', sidebarPath: false }, blog: false, pages: false, theme: {} }]],
};
