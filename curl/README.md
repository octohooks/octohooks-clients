# Octohooks (cURL)

## Getting Started

### Usage

```bash
curl -X 'POST' \
  'https://api.octohooks.com/api/v1/applications/my-application/messages' \
  -H 'accept: application/json' \
  -H 'Authorization: AUTH_TOKEN' \
  -H 'Content-Type: application/json' \
  -d '{
  "channels": [],
  "eventType": "user.created",
  "payload": {
      email: 'foo.bar@example.com',
   }
}'
```
