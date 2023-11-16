# Courses
## Endpoints
### Create Course
- **Short Description:** Creates a new course
- **URL:** `/courses`
- **Method:** `POST`
- **Require Authorization:** `true`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    ```javascript
    {
      "name": string
      "shortDescription": string
      "detailedDescription": string
      "lengthInDays": int
      "price": decimal
      "grantsCertificate": bool
      "certificatePrice": decimal
      "activityFormat": ActivityFormat
      "scheduleType": ScheduleType
      "difficulty": Difficulty
    }
    ```
- **Response Type:**
    ```javascript
    {
      "id": int
      "userId": int
      "name": string
      "shortDescription": string
      "detailedDescription": string
      "lengthInDays": int
      "price": decimal
      "grantsCertificate": bool
      "certificatePrice": decimal
      "activityFormat": ActivityFormat
      "scheduleType": ScheduleType
      "difficulty": Difficulty
      "requirements": CourseRequirement[]?
      "gainedSkills": GainedSkill[]?
      "languages": CourseLanguage[]?
      "subtitles": CourseSubtitle[]?
      "isHidden": bool
    }
- **Sample Request:** `POST /courses`
  ```json
    {
      "name": "Example course"
      "shortDescription": "Short desc"
      "detailedDescription": "Long description"
      "lengthInDays": "15"
      "price": "19.99"
      "grantsCertificate": false
      "certificatePrice": 0
      "activityFormat": "2"
      "scheduleType": "1"
      "difficulty": "0"
    }  
  ```
- **Response Codes:**
  - Course successfully created: `201 Created`
    - **Sample Response:**
      ```json
      {
          "id": 3,
          "userId": 2,
          "name": "Example course",
          "shortDescription": "Short desc",
          "detailedDescription": "Long description",
          "lengthInDays": 15,
          "price": 19.99,
          "grantsCertificate": false,
          "certificatePrice": 0,
          "activityFormat": "Mixed",
          "scheduleType": "Flexible",
          "difficulty": "Beginner",
          "requirements": null,
          "gainedSkills": null,
          "languages": null,
          "subtitles": null,
          "isHidden": true
      }
      ```
### Delete Course
- **Short Description:** Deletes specified course
- **URL:** `/courses/{id}`
- **Method:** `DELETE`
- **Require Authorization:** `true`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    - `id`: int 
- **Response Type:** `-`
- **Sample Request:** `DELETE /courses/15`
- **Response Codes:**
  - Course deleted successfully: `204 No Content`
  - Course not found: `404 Not Found` 
### Get Course
- **Short Description:** Gets a course, hidden courses are returned if requested by the owner
- **URL:** `/courses/{id}`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    - `id`: int 
- **Response Type:**
    ```javascript
    {
      "id": int
      "userId": int
      "name": string
      "shortDescription": string
      "detailedDescription": string
      "lengthInDays": int
      "price": decimal
      "grantsCertificate": bool
      "certificatePrice": decimal
      "activityFormat": ActivityFormat
      "scheduleType": ScheduleType
      "difficulty": Difficulty
      "requirements": CourseRequirement[]
      "gainedSkills": GainedSkill[]
      "languages": CourseLanguage[]
      "subtitles": CourseSubtitle[]
      "isHidden": bool
    }
- **Sample Request:** `GET /courses/10`
- **Response Codes:**
  - Course successfully created: `200 Ok`
    - **Sample Response:**
      ```json
      {
          "id": 3,
          "userId": 2,
          "name": "Example course",
          "shortDescription": "Short desc",
          "detailedDescription": "Long description",
          "lengthInDays": 15,
          "price": 19.99,
          "grantsCertificate": false,
          "certificatePrice": 0,
          "activityFormat": "Mixed",
          "scheduleType": "Flexible",
          "difficulty": "Beginner",
          "requirements": null,
          "gainedSkills": null,
          "languages": null,
      }
      ```
    - Course not found: `404 Not Found`
### Get Course List
- **Short Description:** Gets course list. Hidden courses are returned if requested by the owner
- **URL:** `/courses`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    - `phrase`: string
    - `skip`: int
    - `take`: int 
- **Response Type:**
    ```javascript
    [
        {
          "id": int
          "userId": int
          "name": string
          "shortDescription": string
          "detailedDescription": string
          "lengthInDays": int
          "price": decimal
          "grantsCertificate": bool
          "certificatePrice": decimal
          "activityFormat": ActivityFormat
          "scheduleType": ScheduleType
          "difficulty": Difficulty
          "requirements": CourseRequirement[]
          "gainedSkills": GainedSkill[]
          "languages": CourseLanguage[]
          "subtitles": CourseSubtitle[]
          "isHidden": bool
        }
    ]
    ```
- **Sample Request:** `GET /courses?phrase=example&skip=10&take=5`
- **Response Codes:**
  - Courses are returned successfully: `200 Ok`
    - **Sample Response:**
      ```json
      [
          {
              "id": 3,
              "userId": 2,
              "name": "Example course",
              "shortDescription": "Short desc",
              "detailedDescription": "Long description",
              "lengthInDays": 15,
              "price": 19.99,
              "grantsCertificate": false,
              "certificatePrice": 0,
              "activityFormat": "Mixed",
              "scheduleType": "Flexible",
              "difficulty": "Beginner",
              "requirements": null,
              "gainedSkills": null,
              "languages": null,
          }
      ]
      ```
### Get Course Count
- **Short Description:** Gets a course count given search phrase
- **URL:** `/courses/count`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    - `phrase`: string
- **Response Type:**
    ```javascript
    {
        "count": int
    }
    ```
- **Sample Request:** `GET /courses/count?phrase=example`
- **Response Codes:**
  - Courses are returned successfully: `200 Ok`
    - **Sample Response:**
      ```json
      {
        "count": 15
      }
      ```
### Update Course
- **Short Description:** Creates a new course
- **URL:** `/courses/{id}`
- **Method:** `PUT`
- **Require Authorization:** `true`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
    - `id`: int 
    ```javascript
    {
        "name": string?
        "shortDescription": string?
        "detailedDescription": string?
        "lengthInDays": int?
        "price": decimal?
        "grantsCertificate": bool?
        "certificatePrice": decimal?
        "activityFormat": ActivityFormat?
        "scheduleType": ScheduleType?
        "difficulty": Difficulty?
        "isHidden": bool?
    }
    ```
- **Response Type:**
    ```javascript
    {
      "id": int
      "userId": int
      "name": string
      "shortDescription": string
      "detailedDescription": string
      "lengthInDays": int
      "price": decimal
      "grantsCertificate": bool
      "certificatePrice": decimal
      "activityFormat": ActivityFormat
      "scheduleType": ScheduleType
      "difficulty": Difficulty
      "requirements": CourseRequirement[]?
      "gainedSkills": GainedSkill[]?
      "languages": CourseLanguage[]?
      "subtitles": CourseSubtitle[]?
      "isHidden": bool
    }
- **Sample Request:** `POST /courses/5`
  ```json
    {
      "name": "Example course"
      "shortDescription": "Short desc"
      "detailedDescription": "Long description"
      "lengthInDays": "15"
      "price": "19.99"
      "grantsCertificate": false
      "certificatePrice": 0
      "activityFormat": "2"
      "scheduleType": "1"
      "difficulty": "0",
      "isHidden": false
    }  
  ```
- **Response Codes:**
  - Course successfully created: `200 Ok`
    - **Sample Response:**
      ```json
      {
          "id": 3,
          "userId": 2,
          "name": "Example course",
          "shortDescription": "Short desc",
          "detailedDescription": "Long description",
          "lengthInDays": 15,
          "price": 19.99,
          "grantsCertificate": false,
          "certificatePrice": 0,
          "activityFormat": "Mixed",
          "scheduleType": "Flexible",
          "difficulty": "Beginner",
          "requirements": null,
          "gainedSkills": null,
          "languages": null,
          "subtitles": null,
          "isHidden": false
      ```
    - Course not found: `404 Not Found`
