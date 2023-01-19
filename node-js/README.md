# Octohooks (JavaScript/TypeScript)

## Getting Started

### Installation

Install the package with:

```sh
npm install octohooks
# or
yarn add octohooks
```

### Usage

```typescript
import { Octohooks } from 'octohooks';

const octohooks = new Octohooks('AUTH_TOKEN');

(async () => {
  const application = await octohooks.application.create({
    name: 'My Application',
    uid: 'my-application',
  });

  const endpoint = await octohooks.endpoint.create(application.id, {
    channels: [],
    enabled: true,
    eventTypes: ['user.created'],
    headers: {},
    name: 'My Endpoint',
    uid: 'my-endpoint',
    url: 'https://....',
  });

  const message = await octohooks.message.create(application.id, {
    channels: [],
    eventType: 'user.created',
    payload: {
      email: 'foo.bar@example.com',
    },
  });
})();
```
